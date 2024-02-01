variable "google_project" {
  type = string
  description = "GCP project to deploy resources in"
}

variable "images_bucket_name" {
 type = string
 description = "Name of the bucket to store images in"
}

variable "location" {
 type = string
 default = "europe-central2"
 description = "Gcp region to deploy resources in"
}

provider "google" {
  project = var.google_project
}

resource "google_storage_default_object_access_control" "public_rule" {
  bucket = google_storage_bucket.images_bucket.name
  role   = "READER"
  entity = "allUsers"
}

resource "google_storage_bucket" "images_bucket" {
 name          = var.images_bucket_name
 location      = var.location
 storage_class = "STANDARD"
 uniform_bucket_level_access = false
}