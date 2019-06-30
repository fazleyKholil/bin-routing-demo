# bin-routing-demo
##Test

###Installing terraform
```bash
sudo apt-get install unzip
wget https://releases.hashicorp.com/terraform/0.11.10/terraform_0.11.10_linux_amd64.zip
unzip terraform_0.11.10_linux_amd64.zip
sudo mv terraform /usr/local/bin/
terraform --version 

token
your_token_here


variable "do_token" {}
variable "pub_key" {}
variable "pvt_key" {}
variable "ssh_fingerprint" {}

provider "digitalocean" {
  token =token_here
}
```
