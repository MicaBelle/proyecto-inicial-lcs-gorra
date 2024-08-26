
resource "aws-instance" "test" { 
    ami = 
    instance_type = "t2.micro"
    availability_zone = "us-east-1a"
    key_name = vars.key_name
    vpc_security_groups-ids = [""] 
    tags {
        Name = "test1"
    }
}

resource "aws_s3_bucket" "gorra_bucket" {
    bucket = var.bucket_name
    acl = "private"
}

resource "aws_instance" "test_inst" { 
    ami = var.AMI[var.REGION]
    instance_type = "t2.micro"
    availability_zone = var.ZONE1
    key_name = "test_key"
    vpc_security_groups_ids = ["<sg_id>"]

    tags {
        name = "Test_instance"
        project = "GORRA"
    }
}