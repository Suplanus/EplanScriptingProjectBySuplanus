' GedActionToggleConstructionMode + GedToggleObjectSnapAction, Version 1.0.0, vom 27.07.2012
'
' Copyright by Frank Schöneck, 2012
'
' für Eplan Electric P8, ab V2.1.6
'
'
Public Class GedToggleObjectAction_Class

	<DeclareEventHandler("onActionStart.String.XGedActionToggleConstructionMode")> _
	Public Function GedActionToggleConstructionMode(ByVal iEventParameter As IEventParameter) As Long
		Dim CLI As New CommandLineInterpreter()
		CLI.Execute("XGedToggleObjectSnapAction") 'Objektfang
	End Function

End Class
