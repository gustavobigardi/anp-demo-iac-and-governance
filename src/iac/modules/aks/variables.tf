variable "name" {
  type        = string
  description = "aks name"
  default     = "piloto-aks"
}

variable "environment" {
  type        = string
  description = "Name of the deployment environment"
  default     = "dev"
}

// Resource information

variable "location" {
  type        = string
  description = "Location of the azure resource group."
  default     = "EastUS"
}

variable "resource_group_name" {
  type        = string
  description = "Name of the azure resource group."
  default     = "piloto-rg"
}
  
// Node type information

variable "node_count" {
  type        = string
  description = "The number of K8S nodes to provision."
  default     = 3
}

variable "node_type" {
  type        = string
  description = "The size of each node."
  default     = "Standard_D2s_v3"
}

variable "dns_prefix" {
  type        = string
  description = "DNS Prefix"
  default     = "tfpiloto"
}