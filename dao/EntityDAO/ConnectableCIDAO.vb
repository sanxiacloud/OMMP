Imports ommp.dto
Imports Foxtable
Namespace dao

    Public Class ConnectableCIDAO
        Inherits PhysicalDeviceDAO

        Private Const _TABLE_NAME = ConnectableCI.TABLE_NAME

        Protected Function InsertConnectableCI(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As ConnectableCI = CType(o, ConnectableCI)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertPhysicalDevice(o, finalclass)

                Dim dr As DataRow = DataTables(_TABLE_NAME).AddNew()

                dr(C_ID) = identify
                dr(C__ISDELETED) = False

                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Protected Function UpdateConnectableCI(ByVal o As Object) As Boolean
            Dim obj As ConnectableCI = CType(o, ConnectableCI)
            Dim result As Boolean = False

            Try
                Dim result1 As Boolean = UpdatePhysicalDevice(o)

                Dim dr As DataRow = DataTables(_TABLE_NAME).Find(C_ID & " = " & obj._Identify)
                Dim result2 As Boolean = False
                If dr IsNot Nothing Then
                    ' Nothing is to updated
                    result2 = True

                End If

                result = result1 And result2
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Return result
        End Function

        Protected Function DeleteConnectableCI(ByVal id As Integer) As Boolean

            Return DeletePhysicalDevice(id) And DeleteObject(Of ConnectableCI)(id)

        End Function
    End Class
End Namespace
