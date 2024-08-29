##CONFIGURACIONES DE VPC Y SUBNETEO##

#Creamos la VPC donde hostearemos todo 
resource "aws_vpc" "gorra_vpc" {
  cidr_block = "10.0.0.0/16"
  tags = {
    Name = "gorra-vpc"
  }
}

#Creamos la Public Subnet
resource "aws_subnet" "gorra_public_subnet" {
  vpc_id                  = aws_vpc.gorra_vpc.id
  cidr_block              = "10.0.1.0/24"
  availability_zone       = var.ZONE1
  map_public_ip_on_launch = true
  tags = {
    Name = "gorra-public-subnet"
  }
}

#Creamos el Instranet Gateway
resource "aws_internet_gateway" "gorra_igw" {
  vpc_id = aws_vpc.gorra_vpc.id
  tags = {
    Name = "gorra-igw"
  }
}

#Creamos la Route Table 
resource "aws_route_table" "gorra_route_table" {
  vpc_id = aws_vpc.gorra_vpc.id
  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_internet_gateway.gorra_igw.id
  }
  tags = {
    Name = "gorra-route-table"
  }
}

#Associamos la Route Table con la Subnet
resource "aws_route_table_association" "gorra_route_table_assoc" {
  subnet_id      = aws_subnet.gorra_public_subnet.id
  route_table_id = aws_route_table.gorra_route_table.id
}

##CREACION Y CONFIGURACION DE SG##

resource "aws_security_group" "gorra_sg" {
  name        = "gorra-sg"
  description = "Security group for web app Gorra"
  vpc_id      = aws_vpc.gorra_vpc.id

  #Inbound rules
  ingress {
    description = "Allow SSH from a specific IP address"
    from_port   = 22
    to_port     = 22
    protocol    = "tcp"
    cidr_blocks = ["${var.my_ip}/32"]
  }

  ingress {
    description = "Allow HTTP from anywhere"
    from_port   = 80
    to_port     = 80
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    description = "Allow HTTPS from anyehere"
    from_port   = 443
    to_port     = 443
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  #Outbound rules
  egress {
    description = "Allow all outbound traffic"
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
  tags = {
    Name = "gorra-sg"
  }
}

## CREACION DE LA EC2##

resource "aws_instance" "gorra_frontend" {
  ami                    = var.AMIS[var.REGION]
  instance_type          = "t2.micro"
  availability_zone      = var.ZONE1
  key_name               = var.key_name
  vpc_security_group_ids = [aws_security_group.gorra_sg.id]
  subnet_id              = aws_subnet.gorra_public_subnet.id

  tags = {
    Name    = "gorra_frontend"
    Project = "GORRA"
  }
}

##CREAMOS UN ROL PARA LA EC2 DONDE PUEDA VER EL ECR##
resource "aws_iam_role" "ec2_role" { 
  name = "ec2-role"
 
 assume_role_policy = << EOF
# Create IAM Role for EC2 Instance
resource "aws_iam_role" "ec2_role" {
  name = "ec2-role"

  assume_role_policy = <<EOF
  {
    "Version": "2012-10-17",
    "Statement": [
      {
        "Effect": "Allow",
        "Principal": {
          "Service": "ec2.amazonaws.com"
        },
        "Action": "sts:AssumeRole"
      }
    ]
  }
  EOF
}

# Attach Policy to IAM Role to Allow Access to ECR
resource "aws_iam_role_policy_attachment" "ecr_access" {
  role       = aws_iam_role.ec2_role.name
  policy_arn = "arn:aws:iam::aws:policy/AmazonEC2ContainerRegistryReadOnly"
}

# Create IAM Instance Profile
resource "aws_iam_instance_profile" "ec2_profile" {
  name = "ec2-instance-profile"
  role = aws_iam_role.ec2_role.name
}

}

##CREAMOS LA EC2##

resource "aws_instance" "gorra_backend" {
  ami                    = var.AMIS[var.REGION]
  instance_type          = "t2.micro"
  availability_zone      = var.ZONE1
  key_name               = var.key_name
  vpc_security_group_ids = [aws_security_group.gorra_sg.id]
  subnet_id              = aws_subnet.gorra_public_subnet.id
  
  user_data = <<-EOF
                #!/bin/bash
                yum update -y
                yum install -y docker
                service docker start
                usermod -aG docker ec2-user
                aws ecr get-login-password --region ${var.REGION} | docker login --username AWS --password-stdin ${var.AWS_ACCOUNT_ID}.dkr.ecr.${var.REGION}.amazonaws.com
                docker pull ${var.AWS_ACCOUNT_ID}.dkr.ecr.${var.REGION}.amazonaws.com/backend-repo:latest
                docker run -d -p 8080:8080 ${var.AWS_ACCOUNT_ID}.dkr.ecr.${var.REGION}.amazonaws.com/backend-repo:latest
              EOF
  

  tags = {
    Name    = "gorra_backend"
    Project = "GORRA"
  }
}