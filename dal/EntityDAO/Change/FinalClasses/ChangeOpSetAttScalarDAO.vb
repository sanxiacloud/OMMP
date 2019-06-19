Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class ChangeOpSetAttScalarDAO
        Inherits ChangeOpDAO
        Implements IEntityDAO

        Public Sub New()
            Dim qtObject As New ChangeOpSetAttScalarQT()
            Dim baseObject As New ChangeOp()
            Dim finalObject As New ChangeOpSetAttScalar()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of ChangeOpSetAttScalar)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return False  ' ��ʵ��ɾ������
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As ChangeOpSetAttScalar = CType(o, ChangeOpSetAttScalar)
            obj.id = InsertChangeOp(o, obj.GetType().Name)
            Return InsertObject(Of ChangeOpSetAttScalar)(CType(o, ChangeOpSetAttScalar))
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return False  ' ��ʵ�ָ��·���
        End Function

    End Class

End Namespace