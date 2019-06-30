variable "do_token" { default = "token_here" }
variable "pub_key" { default = "~/.ssh/id_rsa.pub" }
variable "pvt_key" { default = "~/.ssh/id_rsa" }
variable "ssh_fingerprint" { default = "67:1f:2f:ac:3c:29:f2:95:09:de:11:4d:2e:f5:ca:0b" }

provider "digitalocean" {
  token = "${var.do_token}"
}