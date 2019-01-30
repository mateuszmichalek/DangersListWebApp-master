param([Parameter(Mandatory=$true)] [String] $resourceGroup,[Parameter(Mandatory=$false)] [String[]] $resourceTypes = @('Microsoft.Web/sites', 'microsoft.Sql/servers'))

<#
.SYNOPSIS

Removes resources of given type from selected resource group

.DESCRIPTION

Usage: removeResources -resourceGroup <Resource group name> [-resourceTypes [TesourceType1,ResourceType2,...]]
Default resource types: 

#>
try{
    Connect-AzureRmAccount
    foreach($resourceType in $resourceTypes){
        $resources = Get-AzureRmResource -ResourceGroupName $resourceGroup -ResourceType $resourceType
        foreach($resource in $resources){
            Remove-AzureRmResource -ResourceId $resource.ResourceId -Verbose -Force
            'Removed Resource: ' + $resource.Name
        }
    }
}catch{
    Write-Host $_.Exception.Message -ForegroundColor Red
}finally{
    Disconnect-AzureRmAccount
}
    
