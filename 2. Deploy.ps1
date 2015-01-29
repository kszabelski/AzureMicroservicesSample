# Pre requirements
# - connection strings must be set to point your DB
# - deployment package is created

######### to customize ################
## below names must be globaly uniqe ##
$defaultStorageName = "amsdefaultstoreszabl" #just used for deployment
$cloudServiceName = "amsszabl"

#######################################

$deploymentSlot = "Production"
$packageUrl = 'E:\git\_testProjects\AzureMicroservicesSample\AzureMicroservicesSample.AzureCloudServiceDeployment\bin\Release\app.publish\AzureMicroservicesSample.AzureCloudServiceDeployment.cspkg'
$cfgUrl = 'E:\git\_testProjects\AzureMicroservicesSample\AzureMicroservicesSample.AzureCloudServiceDeployment\bin\Release\app.publish\ServiceConfiguration.Cloud.cscfg'

# TODO: where logs gointo when deploying this way?
# next create shutdown and wake up scripts.

#Add-AzureAccount

$defaultStorage = Get-AzureStorageAccount -StorageAccountName $defaultStorageName -ErrorVariable a -ErrorAction silentlycontinue
if ($defaultStorage -eq $null) {
    New-AzureStorageAccount -StorageAccountName $defaultStorageName -Location "West Europe"
    Write-Host "Default storage account created"
}

# AFAIK this default subsctiopion is used to upload package, that is later doployed to Cloud Service
$azureSubscription = Get-AzureSubscription
Set-AzureSubscription -SubscriptionName $azureSubscription.SubscriptionName -CurrentStorageAccountName $defaultStorageName
Write-Host "Default storage account set for subscription"

$service = Get-AzureService -ServiceName $cloudServiceName -ErrorVariable a -ErrorAction silentlycontinue
if ($service -eq $null) {
    New-AzureService -ServiceName $cloudServiceName -Location "West Europe"
    Write-Host "New service created"
}

# Clear existing deployment
$existingDeployment = Get-AzureDeployment -ServiceName $cloudServiceName -Slot $deploymentSlot -ErrorVariable a -ErrorAction silentlycontinue
if ($existingDeployment -ne $null) {
    Remove-AzureDeployment -ServiceName $cloudServiceName -Slot $deploymentSlot -Force
    Write-Host "Removed existing deployment"
}

Write-Host "Uploading new package from $packageUrl"
New-AzureDeployment -ServiceName $cloudServiceName -Slot $deploymentSlot -Package $packageUrl -Configuration $cfgUrl

Write-Host "Finished"
Read-host