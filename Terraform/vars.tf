variable "REGION" {
    default = "us-east-1"
}

variable "ZONE1" {
    default = "us-east-1a"
}

variable "AMIS" { 
    type    = map(string)
    default = { 
        us-east-2 = "ami-0c55b159cbfafe1f0" 
        us-east-1 = "ami-0c55b159cbfafe1f0"
    }
}


variable "bucket_name" { 
    description = "Bucket del sistema Gorra"
    type = string 
    default = "gorra_bucket_2024"
}

variable "key_name" {
    description = "Key pair name for EC2 instance"
    type = string 
    default = "test_key" #reemplazar con un key_name 
}

variable "my_ip" {
    description = "My personal IP, change if necessary"
    default = "190.195.209.92"
}

variable "vpc_id" { 
    description: "The ID of the VPC where resources will be created"
    type = string
    default = "aws_vpc.gorra_vpc.id" 
}