#VARS.TF
variable "REGION" {
  default = "us-east-1"
}

variable "ZONE1" {
  default = "us-east-1a"
}

variable "AMIS" {
  type = map(string)
  default = {
    us-east-2 = "ami-085f9c64a9b75eed5"
    us-east-1 = "ami-0e86e20dae9224db8"
  }
}

variable "key_name" {
  description = "Key pair name for EC2 instance"
  type        = string
  default     = "gorra-key-pair"
}

variable "my_ip" {
  description = "My personal IP, change if necessary"
  default     = "190.195.209.92"
}

variable "vpc_id" {
  description = "The ID of the VPC where resources will be created"
  type        = string
  default     = "aws_vpc.gorra_vpc.id"
}

variable "AWS_ACCOUNT_ID" {
  description = "AWS account ID"
  type        = string
  default     = "778425189746"
}