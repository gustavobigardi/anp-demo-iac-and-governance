resource "azurerm_resource_group" "rg" {
  name     = "rg_cloud-morning-deploy"
  location = "brazilsouth"
  tags     = var.tags
}

//VNET e Subnets
resource "azurerm_virtual_network" "vnet" {
  name                = "vnet-piloto"
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  address_space       = ["10.21.0.0/16"]
  depends_on          = [azurerm_resource_group.rg]
}

resource "azurerm_subnet" "akssubnet" {
  name                 = "subnet-aks"
  resource_group_name  = azurerm_resource_group.rg.name
  virtual_network_name = azurerm_virtual_network.vnet.name
  address_prefixes     = ["10.21.2.0/24"]
  depends_on          = [azurerm_resource_group.rg]
}

//storage
//module "storage" {
//  source               = "./modules/storage"
//  storage_account_name = "cloud-morningstorage"
//  resource_group_name  = azurerm_resource_group.rg.name
//  location             = "brazilsouth"
//  depends_on           = [azurerm_resource_group.rg]
//}

//acr
module "acr" {
  source              = "./modules/acr"
  name                = "acrcloud-morningdemo"
  resource_group_name = azurerm_resource_group.rg.name
  location            = "brazilsouth"
  sku_name            = "Basic"
  depends_on               = [azurerm_resource_group.rg]
}

//exemplo teste aks
resource "azurerm_kubernetes_cluster" "aks" {
  name                = "aks-cloud-morning-demo"
  location            = "brazilsouth"
  resource_group_name = azurerm_resource_group.rg.name
  dns_prefix          = "aks-cloud-morning-demo"
  depends_on               = [azurerm_resource_group.rg]

  default_node_pool {
    name       = "default"
    node_count = "2"
    vm_size    = "standard_d2_v2"
  }
  identity {
    type = "SystemAssigned"
  }
}

resource "azurerm_kubernetes_cluster_node_pool" "mem" {
  kubernetes_cluster_id = azurerm_kubernetes_cluster.aks.id
  name                  = "mem"
  node_count            = "2"
  vm_size               = "standard_d11_v2"
  
}