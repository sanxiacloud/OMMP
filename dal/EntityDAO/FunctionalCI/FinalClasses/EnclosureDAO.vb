Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class EnclosureDAO
        Inherits ConnectableCIDAO(Of Enclosure)
        Implements IEntityDAO

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New EnclosureQT()
            Dim baseObject As New FunctionalCI()
            Dim joinObject1 As New PhysicalDevice()
            Dim joinObject2 As New ConnectableCI()
            Dim finalObject As New Enclosure()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name
            Dim joinTableName2 = joinObject2.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, joinTableName2, C_ID)
            builder.AddTable(joinTableName2, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of Enclosure)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As Enclosure = CType(o, Enclosure)
            obj.id = InsertConnectableCI(o, obj.GetType().Name)
            Return InsertObject(Of Enclosure)(obj) And BuildJoinTable()
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateConnectableCI(o) And UpdateObject(Of Enclosure)(CType(o, Enclosure)) And BuildJoinTable()
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteConnectableCI(id) And DeleteObject(Of Enclosure)(id) And BuildJoinTable()
        End Function

        Public Function Find(ByVal id As Integer) As Enclosure
            Return FindObject(Of Enclosure)(id)
        End Function

        Public Function List(ByVal Optional filter As String = "", ByVal Optional sort As String = Nothing) As IList(Of Enclosure)
            Return FindList(Of Enclosure)(filter, sort)
        End Function
    End Class

End Namespace