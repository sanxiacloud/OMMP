

Imports ommp.dal.dto

Namespace dal.dao
    Public Class SoftwareInstanceDAO
        Inherits FunctionalCIDAO

        Protected Function InsertSoftwareInstance(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As SoftwareInstance = CType(o, SoftwareInstance)
            obj.id = InsertFunctionalCI(o, finalclass)
            Return InsertObject(Of ommp.dal.dto.SoftwareInstance)(CType(o, SoftwareInstance))
        End Function

        Protected Function UpdateSoftwareInstance(ByVal o As Object) As Boolean
            Return UpdateFunctionalCI(o) And UpdateObject(Of SoftwareInstance)(CType(o, SoftwareInstance))
        End Function

        Protected Function DeleteSoftwareInstance(ByVal id As Integer) As Boolean
            Return DeleteFunctionalCI(id) And DeleteObject(Of SoftwareInstance)(id)
        End Function

    End Class

End Namespace
