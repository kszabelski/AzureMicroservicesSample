######### to customize ################
## below name must be globaly uniqe ##
$ordersDatabaseName = "ams_orders_szabl"

#######################################
$adminLogin = "jurassic"
$adminPass = "jur@ssic_Pass1"

if ((Get-AzureAccount) -eq $null) {
	Add-AzureAccount
}
	
# Create database
$sqlServer = New-AzureSqlDatabaseServer -Location "West Europe" -AdministratorLogin $adminLogin -AdministratorLoginPassword $adminPass
Write-Host "New SQL Server Created"

$ruleName = [guid]::NewGuid().ToString()
$ipAddress  = (Invoke-WebRequest 'http://api.ipify.org').Content

New-AzureSqlDatabaseServerFirewallRule -ServerName $sqlServer.ServerName -AllowAllAzureServices
New-AzureSqlDatabaseServerFirewallRule -ServerName $sqlServer.ServerName -RuleName $ruleName -StartIPAddress $ipAddress -EndIPAddress $ipAddress
Write-Host "Enabled server access from " $ipAddress

New-AzureSqlDatabase -ServerName $sqlServer.ServerName -DatabaseName $ordersDatabaseName #-Edition Basic # for some reason in Free Trial subscription i could create only "Web" edition
   
Write-Host "Created new database"

$connectionString = "Server=tcp:{0}.database.windows.net;Database={1};User ID={2}@{0};Password={3};Trusted_Connection=False;Encrypt=True;Connection Timeout=30;" -f $sqlServer.ServerName, $ordersDatabaseName, $adminLogin, $adminPass

Write-Host "Finished"
Write-Host "==================="
Write-Host "Now take connection string below and insert it into your web.configs of"
Write-Host "- AzureMicroservicesSample.Web"
Write-Host "- AzureMicroservicesSample.OrderService"
Write-Host "under AzureMicroservicesSample.OrderService.Entities.OrdersContext key"
Write-Host "==================="
Write-Host $connectionString
Write-Host "==================="

Read-host

