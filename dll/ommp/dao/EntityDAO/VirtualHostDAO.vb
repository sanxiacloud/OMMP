Imports ommp.dto
Imports Foxtable

Namespace dao

    Public Class VirtualHostDAO
        Inherits VirtualDeviceDAO

        Private Const TABLE_NAME As String = VirtualHost.TABLE_NAME

        Protected Function InsertVirtualHost(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As VirtualHost = CType(o, VirtualHost)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertVirtualDevice(o, finalclass)

                Dim dr As DataRow = DataTables(TABLE_NAME).AddNew()

                dr(C_ID) = identify
                If obj.IsDeleted = True Or obj.IsDeleted = False Then
                    dr(C__ISDELETED) = obj.IsDeleted
                Else
                    dr(C__ISDELETED) = False
                End If

                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

    End Class

End Namespace
