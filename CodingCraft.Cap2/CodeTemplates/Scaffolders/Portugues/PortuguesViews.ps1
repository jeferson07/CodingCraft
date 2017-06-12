#
# Geração de Views
#

[T4Scaffolding.Scaffolder(Description = "Adds ASP.NET MVC views for Create/Read/Update/Delete/Index scenarios")][CmdletBinding()]
param(        
    [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, Position = 0)][string]$Controller,
    [string]$ModelType,
    [string]$Area,
    [alias("MasterPage")]$Layout = "",  # If not set, we'll use the default layout
    [alias("ContentPlaceholderIDs")][string[]]$SectionNames,
    [alias("PrimaryContentPlaceholderID")][string]$PrimarySectionName,
    [switch]$ReferenceScriptLibraries = $false,
    [string]$Project,
    [string]$CodeLanguage,
    [string[]]$TemplateFolders,
    [string]$ViewScaffolder = "View",
    [switch]$Force = $false
)

@("Criar", "Editar", "Excluir", "Detalhes", "Index", "_Criar_Bootstrap", "_Criar_Ink", "_Criar_Foundation", "_Editar_Bootstrap", "_Editar_Ink", "_Editar_Foundation","_CriarOuEditar_Bootstrap","_CriarOuEditar_Ink","_CriarOuEditar_Foundation","_Index_Bootstrap", "_Index_Ink", "_Index_Foundation","_Detalhes_Bootstrap", "_Detalhes_Ink", "_Detalhes_Foundation","_Excluir_Bootstrap", "_Excluir_Ink", "_Excluir_Foundation") | %{
    Scaffold $ViewScaffolder -Controller $Controller -ViewName $_ -ModelType $ModelType -Template $_ -Area $Area -Layout $Layout -SectionNames $SectionNames -PrimarySectionName $PrimarySectionName -ReferenceScriptLibraries:$ReferenceScriptLibraries -Project $Project -CodeLanguage $CodeLanguage -OverrideTemplateFolders $TemplateFolders -Force:$Force
}
