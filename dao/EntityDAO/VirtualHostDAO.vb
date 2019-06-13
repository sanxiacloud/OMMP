Imports ommp.dto
Imports Foxtable

Namespace dao

    Public MustInherit Class VirtualHostDAO
        Inherits VirtualDeviceDAO

        Private Const _TABLE_NAME = VirtualHost.TABLE_NAME

        Protected Function UpdateVirtualHost(ByVal o As Object) As Boolean
            Dim obj As VirtualHost = CType(o, VirtualHost)
            Dim result As Boolean = False

            Try
                Dim result1 As Boolean = UpdateVirtualDevice(o)
                Dim result2 As Boolean = False

                Dim dr As DataRow = DataTables(_TABLE_NAME).Find(C_ID & " = " & obj._Identify)

                If dr IsNot Nothing Then
                    ' 此表只包含 id 字段，不做更新

                    result2 = True

                End If

                result = result1 And result2
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Return result
        End Function

        Protected Function DeleteVirtualHost(ByVal id As Integer) As Boolean

            Return DeleteVirtualDevice(id) And DeleteObject(_TABLE_NAME, id)

        End Function

        Protected Function InsertVirtualHost(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As VirtualHost = CType(o, VirtualHost)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertVirtualDevice(o, finalclass)

                Dim dr As DataRow = DataTables(_TABLE_NAME).AddNew()

                dr(C_ID) = identify
                If obj._IsDeleted = True Or obj._IsDeleted = False Then
                    dr(C__ISDELETED) = obj._IsDeleted
                Else
                    dr(C__ISDELETED) = False
                End If

                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function
 
    End Class

End Namespace
