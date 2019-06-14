Imports ommp.dto
Imports Foxtable

Namespace dao

    Public Class CodeDAO
        Inherits BaseDAO
        Implements IEntityDAO


        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Private ReadOnly Property _TABLE_NAME() As String
            Get
                Return Code.TABLE_NAME
            End Get
        End Property



        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As Code = CType(o, Code)
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(_TABLE_NAME).AddNew()

                dr(Code.C_T) = obj.t
                dr(Code.C_V) = obj.v
                dr(Code.C_LABEL) = obj.label
                dr(Code.C_DES) = obj.des
                dr(Code.C__SORTKEY) = obj._SortKey
                If obj._IsDeleted = True Or obj._IsDeleted = False Then
                    dr(Code.C__ISDELETED) = obj._IsDeleted
                Else
                    dr(Code.C__ISDELETED) = False
                End If

                dr.Save()
                result = True
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Dim obj As Code = CType(o, Code)
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(_TABLE_NAME).Find(Code.C__IDENTIFY & " = " & obj._Identify)
                If dr IsNot Nothing Then
                    If obj.t >= 0 Then
                        dr(Code.C_T) = obj.t
                    End If
                    If obj.v >= 0 Then
                        dr(Code.C_V) = obj.v
                    End If
                    If obj.label IsNot Nothing Then
                        dr(Code.C_LABEL) = obj.label
                    End If
                    If obj.des >= 0 Then
                        dr(Code.C_DES) = obj.des
                    End If
                    If obj._IsDeleted = False Or obj._IsDeleted = True Then
                        dr(Code.C__ISDELETED) = obj._IsDeleted
                    End If
                    If obj._SortKey >= 0 Then
                        dr(Code.C__SORTKEY) = obj._SortKey
                    End If
                    dr.Save()
                    result = True
                End If
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Return result
        End Function


        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteObject(Of Code)(id)
        End Function
    End Class

End Namespace