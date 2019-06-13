Imports ommp.dto
Imports Foxtable

Namespace dao

    Public Class CodeDAO
        Inherits BaseDAO
        Implements IEntityDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Protected Overrides ReadOnly Property TABLE_NAME() As String
            Get
                Return Code.TABLE_NAME
            End Get
        End Property

        Protected Overrides Function SetProperties(ByVal dr As DataRow) As Object
            Dim item As New Code()

            item._Identify = dr(Code.C__IDENTIFY)
            item.t = dr(Code.C_T)
            item.v = dr(Code.C_V)
            item.label = dr(Code.C_LABEL)
            item.des = dr(Code.C_DES)
            item._IsDeleted = dr(Code.C__ISDELETED)
            item._SortKey = dr(Code.C__SORTKEY)

            Return item
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Dim result As Boolean = False
            Try
                Dim dr As DataRow = DataTables(TABLE_NAME).Find(Code.C__IDENTIFY & " = " & id)
                dr(Organization.C__ISDELETED) = True
                dr.Save()
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Delete:" & ex.Message)
            End Try

            Return result
        End Function

        Public Function Insert(ByVal o As Object) As Boolean Implements IEntityDAO.Insert
            Dim obj As Code = CType(o, Code)
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(TABLE_NAME).AddNew()

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
                Output.Show(TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Dim obj As Code = CType(o, Code)
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(TABLE_NAME).Find(Code.C__IDENTIFY & " = " & obj._Identify)
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
                Output.Show(TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Return result
        End Function

        Public Function FindList(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of Object) Implements IQueryDAO.FindList
            Return FindRows(TABLE_NAME, filter, sort)
        End Function

        Public Function FindObject(ByVal id As Integer) As Object Implements IQueryDAO.FindObject
            Return FindRow(TABLE_NAME, id)
        End Function
    End Class

End Namespace