# Shared variables --------------------------------------------------------------------------------
$nugetExe = Get-Item .\Source\.nuget\NuGet.exe
$solutionFile = ".\Source\Reflections.sln"

# Standard PowerShell Functions -------------------------------------------------------------------
function Test-ReparsePoint([string]$path) {
  $file = Get-Item $path -Force -ea 0
  return [bool]($file.Attributes -band [IO.FileAttributes]::ReparsePoint)
}


# Psake tasks -------------------------------------------------------------------------------------
task default -depends CleanAll, RestorePackages

task ? -description "Writes task documentation to the console." {
    WriteDocumentation
}

task CleanAll -description "Runs a git clean -xdf.  Prompts first if untracked files are found." {
    $gitStatus = (@(git status --porcelain) | Out-String)

    IF ($gitStatus.Contains("??"))
    {
	    Write-Host "About to delete any untracked files.  Press 'Y' to continue or any other key to cancel." -foregroundcolor "yellow"
	    $continue = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyUp").Character
	    IF ($continue -ne "Y" -and $continue -ne "y")
	    {
		    Write-Error "CleanAll canceled."
	    }
    }

	# test to see if packages is a link or a real directory
	if (Test-ReparsePoint("packages/")) {
		# packages is a NTFS Reparse point
		# delete everything in packages but 
		Echo "Packages is a link. Will keep it but delete its content."
		Remove-Item .\packages\* -Force -Recurse
		git clean -xdf -e "*.suo" -e "packages/"
	} else {
		git clean -xdf -e "*.suo" 
	}
}


task RestorePackages -description "Restores all nuget packages in the solution." {
	exec { & $nugetExe restore $solutionFile }
}