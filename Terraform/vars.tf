variable REGION {
    default = "us-east-1"
}

variable ZONE1 {
    default "us-east-1"
}

variable AMIS { 
    type = map
    default = { 
        us-east-2 = "<ami_id>" #completar
        us-east-1 = "<ami_id>" #completar

    }
}

variable "bucket_name" { 
    description = "Bucket del sistema Gorra"
    type = string 
    default = "gorra_bucket_2024"
}