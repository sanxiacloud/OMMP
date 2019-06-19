Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class SoftwareLicenceDAO
        Inherits LicenceDAO
        Implements IEntityDAO

        Public Sub New()
            Dim qtObject As New SoftwareLicenceQT()
            Dim baseObject As New Licence()
            Dim finalObject As New SoftwareLicence()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of SoftwareLicence)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteLicence(id) And DeleteObject(Of SoftwareLicence)(id)
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As SoftwareLicence = CType(o, SoftwareLicence)
            obj.id = InsertLicence(o, obj.GetType().Name)
            Return InsertObject(Of SoftwareLicence)(CType(o, SoftwareLicence))
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateLicence(o) And UpdateObject(Of SoftwareLicence)(CType(o, SoftwareLicence))
        End Function

    End Class

End Namespace