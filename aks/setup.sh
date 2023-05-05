ResourceGroup="OTEL-AM-DEMO"
AksName="aks-otel-am-cluster"
AcrName=oteldamemo
AcrInstanceName="oteldamemo.azurecr.io"

# Create Aks Resource Group
az group create -l westeurope -n $ResourceGroup

# Create ACR
az acr create -n $AcrName -g $ResourceGroup --sku Standard

# Create AKS
az aks create --resource-group $ResourceGroup --name $AksName --generate-ssh-keys

# Get agentpool id of AKS Cluster
aks_sp_agentpool_id=$(az ad sp list --filter "displayName eq '$AksName-agentpool'" --query '[].appId' --output tsv)

# Get the ACR registry resource id
acr_id=$(az acr show --name $AcrInstanceName --resource-group $ResourceGroup --query "id" --output tsv)

# Create role assignment ACR for AKS
az role assignment create --assignee $aks_sp_agentpool_id --role AcrPull --scope $acr_id

# get connection to aks
az aks get-credentials --resource-group $ResourceGroup --name $AksName --admin

# create prometheus config map which has a custom prometheus scrape file which is used to scrape other pods with the correct annotions specified
# this file is a default used in kubernetes clusters. Note that the microsoft documentation uses an incorrect name for the configmap which
# is actually ending with node
kubectl create configmap ama-metrics-prometheus-config-node --from-file=prometheus-config -n kube-system