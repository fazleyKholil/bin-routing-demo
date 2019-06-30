resource "digitalocean_droplet" "ubuntu-docker-lon" {
    image = "docker-18-04"
    name = "ubuntu-docker-lon"
    region = "LON1"

  connection {
      user = "root"
      type = "ssh"
      private_key = "${file("~/.ssh/id_rsa")}"
      timeout = "2m"
  }

  provisioner "remote-exec" {
    inline = [
      "sudo apt-get update",
       #install ab
       "apt-get install -y apache2-utils",
    ]
  }
}