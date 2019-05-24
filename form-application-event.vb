'''主窗口事件

#Region main

Function AfterLoad(e)
    ' 初始化绘制左边
    Functions.Execute("ReDrawAppTvOrg")

    '禁止各个listview多选
    ' #todo
End Function

#End Region

#Region 应用系统tab

#Region tv_app_org

Function AfterSelectNode(e)
    ' 重新绘制主lsitview
    Functions.Execute("ReDrawAppLvApp")   

End Function

#End Region

#End Region