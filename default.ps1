# Shared variables --------------------------------------------------------------------------------
$msbuildExe = Get-Item "C:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe"
$nugetExe = Get-Item ".\Source\.nuget\NuGet.exe"
$solutionFile = ".\Source\Reflections.sln"

# Standard PowerShell Functions -------------------------------------------------------------------
function Invoke-Compile {    
    [CmdletBinding()]  
    param(  
        [Parameter(Position=0,Mandatory=1)] [string]$slnPath = $null,
        [Parameter(Position=1,Mandatory=0)] [string]$configuration = "Debug",
        [Parameter(Position=2,Mandatory=0)] [string]$platform = "x64",
        [Parameter(Position=3,Mandatory=0)] [bool]$buildViews = 0
	)
    
	Write-Host "Running Build for solution @" $slnPath -ForegroundColor Cyan
    $config = "Configuration=" + $configuration + ";Platform="+ $platform

    if ($buildViews){
        exec { & $msbuildExe $slnPath /m /nologo /p:$($config) /property:MvcBuildViews=true /t:build /v:m }
    }
    else{
        exec { & $msbuildExe $slnPath /m /nologo /p:$($config) /t:build /v:m }
    }

}


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

task BuildDebug -description "Build Reflections.sln in the debug configuration." {
	Invoke-Compile $SolutionFile "Debug" "Mixed Platforms" 1
}

task RestorePackages -description "Restores all nuget packages in the solution." {
	exec { & $nugetExe restore $solutionFile }
}