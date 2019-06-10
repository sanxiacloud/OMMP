Imports ommp.dto
Imports Foxtable

Namespace dao

    Public Class CodeDAO
        Inherits BaseDAO
        Implements IEntityDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Dim result As Boolean = False
            Try
                Dim dr As DataRow = DataTables(Code.TABLE_NAME).Find(Code.C__IDENTIFY & " = " & id)
                dr(Organization.C__ISDELETED) = True
                dr.Save()
            Catch ex As Exception
                Output.Show(Organization.TABLE_NAME & "->Delete:" & ex.Message)
            End Try

            Return result
        End Function

        Public Function FindList(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of Object) Implements IEntityDAO.FindList
            Dim lists As IList(Of Code) = New Generic.List(Of Code)()
            Try
                Dim drs As List(Of DataRow)
                If sort IsNot Nothing Then
                    drs = DataTables(Code.TABLE_NAME).Select(filter, sort)
                Else
                    drs = DataTables(Code.TABLE_NAME).Select(filter)
                End If
                For Each dr As DataRow In drs
                    lists.Add(SetProperties(dr))
                Next
            Catch ex As Exception
                Output.Show(Code.TABLE_NAME & "->FindList:" & ex.Message)
            End Try

            Return lists
        End Function

        Private Function SetProperties(ByVal dr As DataRow) As Code
            Dim item As New Code()

            item.Identify = dr(Code.C__IDENTIFY)
            item.t = dr(Code.C_T)
            item.v = dr(Code.C_V)
            item.label = dr(Code.C_LABEL)
            item.des = dr(Code.C_DES)
            item.IsDeleted = dr(Code.C__ISDELETED)
            item._SortKey = dr(Code.C__SORTKEY)

            Return item
        End Function

        Public Function FindObject(ByVal id As Integer) As Object Implements IEntityDAO.FindObject
            Dim item As New Code()
            Try
                Dim dr As DataRow = DataTables(Code.TABLE_NAME).Find(Code.C__IDENTIFY & " = " & id)
                If dr IsNot Nothing Then
                    item = SetProperties(dr)
                End If
            Catch ex As Exception
                Output.Show(Code.TABLE_NAME & "->FindObject:" & ex.Message)
            End Try

            Return item
        End Function

        Public Function Insert(ByVal o As Object) As Boolean Implements IEntityDAO.Insert
            Dim obj As Code = CType(o, Code)
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(Code.TABLE_NAME).AddNew()

                dr(Code.C_T) = obj.t
                dr(Code.C_V) = obj.v
                dr(Code.C_LABEL) = obj.label
                dr(Code.C_DES) = obj.des
                dr(Code.C__SORTKEY) = obj._SortKey
                If obj.IsDeleted = True Or obj.IsDeleted = False Then
                    dr(Code.C__ISDELETED) = obj.IsDeleted
                Else
                    dr(Code.C__ISDELETED) = False
                End If

                dr.Save()
                result = True
            Catch ex As Exception
                Output.Show(Code.TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Dim obj As Code = CType(o, Code)
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(Code.TABLE_NAME).Find(Code.C__IDENTIFY & " = " & obj.Identify)
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
                    If obj.IsDeleted = False Or obj.IsDeleted = True Then
                        dr(Code.C__ISDELETED) = obj.IsDeleted
                    End If
                    If obj._SortKey >= 0 Then
                        dr(Code.C__SORTKEY) = obj._SortKey
                    End If
                    dr.Save()
                    result = True
                End If
            Catch ex As Exception
                Output.Show(Code.TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Return result
        End Function
    End Class

End Namespace