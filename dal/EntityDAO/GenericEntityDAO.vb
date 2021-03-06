﻿Namespace dal.dao

    Public Class GenericEntityDAO(Of T As New)
		Inherits BaseDAO

		Function Find(id As Integer) As T
			Return FindObject(Of T)(id)
		End Function

		Function Find(filter As String) As T
			Return FindObject(Of T)(filter)
		End Function

		Public Function List(ByVal Optional filter As String = "", ByVal Optional sort As String = Nothing) As IList(Of T)
			Return FindList(Of T)(filter, sort)
		End Function

    End Class
End Namespace
