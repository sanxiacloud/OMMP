Imports ommp.dto
Imports Foxtable
Namespace dao

    Public Class DatabasesSchemaDAO
        Inherits FunctionalCIDAO
        Implements IEntityDAO


        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Private ReadOnly Property _TABLE_NAME() As String
            Get
                Return DatabasesSchema.TABLE_NAME
            End Get
        End Property

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteFunctionalCI(id) And DeleteObject(Of DatabasesSchema)(id)
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As DatabasesSchema = CType(o, DatabasesSchema)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertFunctionalCI(o, _TABLE_NAME)

                Dim dr As DataRow = DataTables(_TABLE_NAME).AddNew()

                dr(C_ID) = identify
                dr(C__ISDELETED) = False
                dr(DatabasesSchema.C_DBSERVER_IDENTIFY) = obj.dbserver_identify
                dr(DatabasesSchema.C_FARM_IDENTIFY) = obj.farm_identify
                dr(DatabasesSchema.C_PDB_NAME) = obj.pdb_name
                dr(DatabasesSchema.C_COMMENT) = obj.comment
                dr(DatabasesSchema.C_CREATE_TIME) = obj.create_time
                dr(DatabasesSchema.C_INDIVIDUAL) = obj.individual

                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Dim obj As DatabasesSchema = CType(o, DatabasesSchema)
            Dim result As Boolean = False

            Try
                Dim result1 As Boolean = UpdateFunctionalCI(o)
                Dim result2 As Boolean = False

                Dim dr As DataRow = DataTables(_TABLE_NAME).Find(C_ID & " = " & obj._Identify)

                If dr IsNot Nothing Then
                    If obj.dbserver_identify >= 0 Then
                        dr(DatabasesSchema.C_DBSERVER_IDENTIFY) = obj.dbserver_identify
                    End If
                    If obj.farm_identify >= 0 Then
                        dr(DatabasesSchema.C_FARM_IDENTIFY) = obj.farm_identify
                    End If
                    If obj.pdb_name >= 0 Then
                        dr(DatabasesSchema.C_PDB_NAME) = obj.pdb_name
                    End If
                    If obj.comment IsNot Nothing Then
                        dr(DatabasesSchema.C_COMMENT) = obj.comment
                    End If
                    If obj.create_time <> Nothing Then
                        dr(DatabasesSchema.C_CREATE_TIME) = obj.create_time
                    End If
                    If obj.individual IsNot Nothing Then
                        dr(DatabasesSchema.C_INDIVIDUAL) = obj.individual
                    End If

                    dr.Save()
                    result2 = True

                End If

                result = result1 And result2
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Return result
        End Function

    End Class

End Namespace