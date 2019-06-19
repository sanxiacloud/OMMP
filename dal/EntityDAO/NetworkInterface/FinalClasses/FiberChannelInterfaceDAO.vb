Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class FiberChannelInterfaceDAO
        Inherits NetworkInterfaceDAO
        Implements IEntityDAO

        Public Sub New()
            Dim qtObject As New FiberChannelInterfaceQT()
            Dim baseObject As New NetworkInterface()
            Dim finalObject As New FiberChannelInterface()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of FiberChannelInterface)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteNetworkInterface(id) And DeleteObject(Of FiberChannelInterface)(id)
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As FiberChannelInterface = CType(o, FiberChannelInterface)
            obj.id = InsertNetworkInterface(o, obj.GetType().Name)
            Return InsertObject(Of FiberChannelInterface)(CType(o, FiberChannelInterface))
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateNetworkInterface(o) And UpdateObject(Of FiberChannelInterface)(CType(o, FiberChannelInterface))
        End Function


    End Class

End Namespace