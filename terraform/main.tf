resource "aws_instance" "anubhav_instance-2026" {
  for_each      = var.instance_type
  ami           = var.ami_id
  instance_type = each.value

  tags = {
    Name = each.key
  }
}

resource "aws_s3_bucket" "anubhav_instance_bucket-2026" {
  bucket = "bucket-terraform-2840263405"

  tags = {
    Name = "Anubhav-Instance-Bucket"
  }
}
