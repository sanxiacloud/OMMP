Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class FiberChannelInterfaceDAO
        Inherits NetworkInterfaceDAO(Of FiberChannelInterfaceQT)
        Implements IEntityDAO(Of FiberChannelInterface)

        Protected Overrides Function BuildJoinTable() As Boolean
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
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As FiberChannelInterface) As Integer Implements IEntityDAO(Of FiberChannelInterface).Insert
            o.id = InsertNetworkInterface(o, GetType(FiberChannelInterface).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As FiberChannelInterface) As Boolean Implements IEntityDAO(Of FiberChannelInterface).Update
            Return UpdateNetworkInterface(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Private Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of FiberChannelInterface).Delete
            Return DeleteNetworkInterface(id) And DeleteObject(Of FiberChannelInterface)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace