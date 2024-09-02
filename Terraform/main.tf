# MAIN.TF

## CONFIGURACIONES DE VPC Y SUBNETEO ##

# Creamos la VPC donde hostearemos todo
resource "aws_vpc" "gorra_vpc" {
  cidr_block = "10.0.0.0/16"
  tags = {
    Name = "gorra-vpc"
  }
}

# Creamos la Public Subnet
resource "aws_subnet" "gorra_public_subnet" {
  vpc_id                  = aws_vpc.gorra_vpc.id
  cidr_block              = "10.0.1.0/24"
  availability_zone       = var.ZONE1
  map_public_ip_on_launch = true
  tags = {
    Name = "gorra-public-subnet"
  }
}

# Creamos el Internet Gateway
resource "aws_internet_gateway" "gorra_igw" {
  vpc_id = aws_vpc.gorra_vpc.id
  tags = {
    Name = "gorra-igw"
  }
}

# Creamos la Route Table
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

# Asociamos la Route Table con la Subnet
resource "aws_route_table_association" "gorra_route_table_assoc" {
  subnet_id      = aws_subnet.gorra_public_subnet.id
  route_table_id = aws_route_table.gorra_route_table.id
}

## CREACION Y CONFIGURACION DE SECURITY GROUP (SG) ##

resource "aws_security_group" "gorra_sg" {
  name        = "gorra-sg"
  description = "Security group for web app Gorra"
  vpc_id      = aws_vpc.gorra_vpc.id

  # Inbound rules
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
    description = "Allow HTTP from anywhere"
    from_port   = 8080
    to_port     = 8080
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    description = "Allow HTTPS from anywhere"
    from_port   = 443
    to_port     = 443
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  # Outbound rules
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

##CONFIGURACION DE LA EC2##

resource "aws_instance" "gorra_backend" {
  ami                    = var.AMIS[var.REGION]
  instance_type          = "t2.micro"
  availability_zone      = var.ZONE1
  key_name               = var.key_name
  vpc_security_group_ids = [aws_security_group.gorra_sg.id]
  subnet_id              = aws_subnet.gorra_public_subnet.id

  # El script de user_data permanece igual
  user_data = <<-EOF
                #!/bin/bash
                # Update the package manager and install Docker
                sudo apt-get update -y
                sudo apt-get install -y docker.io

                # Start Docker and enable it to start on boot
                sudo systemctl start docker
                sudo systemctl enable docker

                # Add the current user to the Docker group
                sudo usermod -aG docker ubuntu

                # Install the AWS CLI 
                curl "https://awscli.amazonaws.com/awscli-exe-linux-x86_64.zip" -o "awscliv2.zip"
                sudo apt-get install -y unzip
                unzip awscliv2.zip
                sudo ./aws/install

                # Authenticate Docker to AWS ECR
                aws ecr get-login-password --region ${var.REGION} | docker login --username AWS --password-stdin ${var.AWS_ACCOUNT_ID}.dkr.ecr.${var.REGION}.amazonaws.com

                # Pull the Docker image from ECR
                docker pull ${var.AWS_ACCOUNT_ID}.dkr.ecr.${var.REGION}.amazonaws.com/hola-mundo-repo:latest

                # Run the Docker container
                docker run -d -p 8080:8080 ${var.AWS_ACCOUNT_ID}.dkr.ecr.${var.REGION}.amazonaws.com/hola-mundo-repo:latest
              EOF

  # Referenciando el instance profile existente
  iam_instance_profile = "ec2-role-ecr-access" # El nombre del rol que creaste manualmente

  tags = {
    Name    = "gorra_backend"
    Project = "GORRA"
  }
}

#ASOCIAR LA EC2 CON LA IP ELÁSTICA#
resource "aws_eip_association" "gorra_eip_assoc" {
  instance_id   = aws_instance.gorra_backend.id
  allocation_id = "eipalloc-0d7fea5edaba356ab"
}

#CHEQUEAR PUERTO 8080 SI NO ES NECESARIO