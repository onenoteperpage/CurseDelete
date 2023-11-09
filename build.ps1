$items = @("$PSScriptRoot\obj","$PSScriptRoot\bin")
foreach ($item in $items) {
	Get-ChildItem -Path $item -Recurse | ForEach-Object {
		Remove-Item -Path $_.FullName -Recurse -Force -Confirm:$false
	}
}

dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
