Public Class WasserzeichenScript

	<Start> _
	Public Sub WasserZeichen()
		
		Dim parameterContext As New ActionCallingContext
		Dim CommandLineInterpreter As New CommandLineInterpreter()
		Dim sText as string =""
		
		sText = Microsoft.VisualBasic.InputBox("Wasserzeichentext eingeben", "Wasserzeichen", "example drawing" )

		parameterContext.AddParameter("PropertyId",40099)
		parameterContext.AddParameter("PropertyIndex",0) 
		parameterContext.AddParameter("PropertyValue",sText)
		
		CommandLineInterpreter.Execute("XEsSetProjectPropertyAction", parameterContext)
		
		CommandLineInterpreter.Execute("XGedRedrawAction")
		
	End Sub

End Class