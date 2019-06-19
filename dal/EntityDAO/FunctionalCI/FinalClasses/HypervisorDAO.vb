Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class HypervisorDAO
        Inherits VirtualHostDAO
        Implements IEntityDAO

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New HypervisorQT()
            Dim baseObject As New FunctionalCI()
            Dim joinObject1 As New VirtualDevice()
            Dim joinObject2 As New VirtualHost()
            Dim finalObject As New Hypervisor()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name
            Dim joinTableName2 = joinObject2.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, joinTableName2, C_ID)
            builder.AddTable(joinTableName2, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of Hypervisor)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteVirtualHost(id) And DeleteObject(Of Hypervisor)(id) And BuildJoinTable()
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As Hypervisor = CType(o, Hypervisor)
            obj.id = InsertVirtualHost(o, obj.GetType().Name)
            Return InsertObject(Of Hypervisor)(CType(o, Hypervisor)) And BuildJoinTable()
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateVirtualHost(o) And UpdateObject(Of Hypervisor)(CType(o, Hypervisor)) And BuildJoinTable()
        End Function

    End Class

End Namespace