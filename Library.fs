namespace PSWordCloud

open System.Management.Automation
open SkiaSharp

[<Cmdlet(VerbsCommon.New,"WordCloud")>]
type PSWordCloudCommand() as self =
    inherit PSCmdlet()

    //#region parameters
    [<Parameter(Mandatory = true)>]
    member val Path : string list = []
        with get, set
    //#endregion parameters

    //#region overrides
    override PSCmdlet.BeginProcessing() =
        let mutable targetPaths = []
        for path in self.Path do
            let resolvedPaths, providerInfo = self.SessionState.Path.GetResolvedProviderPathFromPSPath path

            if resolvedPaths <> null then
                for item in resolvedPaths do
                    targetPaths <- item :: targetPaths

        self.Path <- targetPaths

    //#endregion overrides
