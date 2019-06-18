Namespace dal.dto
    ' ------------------------------
    ' Others 
    Public Class CIGroup

        Private _code_cigroup_status As Integer
        Private _code_cigroup_type As Integer
        Private _description As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _name As String
        Private _obsolescence_date As Date
        Private _organization_identify As Integer
        Private _parent_identify As Integer

        Public Property code_cigroup_status() As Integer
            Get
                Return _code_cigroup_status
            End Get
            Set(ByVal _code_cigroup_status_value As Integer)
                _code_cigroup_status = _code_cigroup_status_value
            End Set
        End Property

        Public Property code_cigroup_type() As Integer
            Get
                Return _code_cigroup_type
            End Get
            Set(ByVal _code_cigroup_type_value As Integer)
                _code_cigroup_type = _code_cigroup_type_value
            End Set
        End Property

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property obsolescence_date() As Date
            Get
                Return _obsolescence_date
            End Get
            Set(ByVal _obsolescence_date_value As Date)
                _obsolescence_date = _obsolescence_date_value
            End Set
        End Property

        Public Property organization_identify() As Integer
            Get
                Return _organization_identify
            End Get
            Set(ByVal _organization_identify_value As Integer)
                _organization_identify = _organization_identify_value
            End Set
        End Property

        Public Property parent_identify() As Integer
            Get
                Return _parent_identify
            End Get
            Set(ByVal _parent_identify_value As Integer)
                _parent_identify = _parent_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class ConfigAccess

        Private _access_port As String
        Private _description As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _local_ip1_identify As Integer
        Private _local_ip2_identify As Integer
        Private _remote_ip1_identify As Integer
        Private _remote_ip2_identify As Integer

        Public Property Access_port() As String
            Get
                Return _access_port
            End Get
            Set(ByVal _access_port_value As String)
                _access_port = _access_port_value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property Local_ip1_identify() As Integer
            Get
                Return _local_ip1_identify
            End Get
            Set(ByVal _local_ip1_identify_value As Integer)
                _local_ip1_identify = _local_ip1_identify_value
            End Set
        End Property

        Public Property Local_ip2_identify() As Integer
            Get
                Return _local_ip2_identify
            End Get
            Set(ByVal _local_ip2_identify_value As Integer)
                _local_ip2_identify = _local_ip2_identify_value
            End Set
        End Property

        Public Property Remote_ip1_identify() As Integer
            Get
                Return _remote_ip1_identify
            End Get
            Set(ByVal _remote_ip1_identify_value As Integer)
                _remote_ip1_identify = _remote_ip1_identify_value
            End Set
        End Property

        Public Property Remote_ip2_identify() As Integer
            Get
                Return _remote_ip2_identify
            End Get
            Set(ByVal _remote_ip2_identify_value As Integer)
                _remote_ip2_identify = _remote_ip2_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class ConfigPort

        Private _description As String
        Private __Identify As Integer
        Private _ip1_identify As Integer
        Private _ip2_identify As Integer
        Private __IsDeleted As Boolean
        Private _port1 As Integer
        Private _port2 As Integer
        Private _type As Integer

        Public Const TABLE_NAME As String = "ConfigPort"

        Public Const C__IDENTIFY As String = "__Identify"
        Public Const C__ISDELETED As String = "_IsDeleted"
        Public Const C_DESCRIPTION As String = "description"
        Public Const C_IP1_IDENTIFY As String = "ip1_identify"
        Public Const C_IP2_IDENTIFY As String = "ip2_identify"
        Public Const C_PORT1 As String = "port1"
        Public Const C_PORT2 As String = "port2"
        Public Const C_TYPE As String = "type"

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property Ip1_identify() As Integer
            Get
                Return _ip1_identify
            End Get
            Set(ByVal _ip1_identify_value As Integer)
                _ip1_identify = _ip1_identify_value
            End Set
        End Property

        Public Property ip2_identify() As Integer
            Get
                Return _ip2_identify
            End Get
            Set(ByVal _ip2_identify_value As Integer)
                _ip2_identify = _ip2_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property port1() As Integer
            Get
                Return _port1
            End Get
            Set(ByVal _port1_value As Integer)
                _port1 = _port1_value
            End Set
        End Property

        Public Property port2() As Integer
            Get
                Return _port2
            End Get
            Set(ByVal _port2_value As Integer)
                _port2 = _port2_value
            End Set
        End Property

        Public Property type() As Integer
            Get
                Return _type
            End Get
            Set(ByVal _type_value As Integer)
                _type = _type_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class Backups

        Private _backup_content As String
        Private _backuper_identify As Integer
        Private _code_backup_type As String
        Private _description As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _name As String

        Public Const TABLE_NAME As String = "Backups"

        Public Const C__IDENTIFY As String = "__Identify"
        Public Const C__ISDELETED As String = "_IsDeleted"
        Public Const C_BACKUP_CONTENT As String = "backup_content"
        Public Const C_BACKUPER_IDENTIFY As String = "backuper_identify"
        Public Const C_CODE_BACKUP_TYPE As String = "code_backup_type"
        Public Const C_DESCRIPTION As String = "description"
        Public Const C_NAME As String = "name"

        Public Property backup_content() As String
            Get
                Return _backup_content
            End Get
            Set(ByVal _backup_content_value As String)
                _backup_content = _backup_content_value
            End Set
        End Property

        Public Property backuper_identify() As Integer
            Get
                Return _backuper_identify
            End Get
            Set(ByVal _backuper_identify_value As Integer)
                _backuper_identify = _backuper_identify_value
            End Set
        End Property

        Public Property code_backup_type() As String
            Get
                Return _code_backup_type
            End Get
            Set(ByVal _code_backup_type_value As String)
                _code_backup_type = _code_backup_type_value
            End Set
        End Property

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class Code

        Private __SortKey As Decimal
        Private _des As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _label As String
        Private _t As String
        Private _v As Integer

        Public Const TABLE_NAME As String = "Code"

        Public Const C__IDENTIFY As String = "__Identify"
        Public Const C__ISDELETED As String = "_IsDeleted"
        Public Const C__SORTKEY As String = "_SortKey"
        Public Const C_DES As String = "des"
        Public Const C_LABEL As String = "label"
        Public Const C_T As String = "t"
        Public Const C_V As String = "v"

        Public Property _SortKey() As Decimal
            Get
                Return __SortKey
            End Get
            Set(ByVal __SortKey_value As Decimal)
                __SortKey = __SortKey_value
            End Set
        End Property

        Public Property des() As String
            Get
                Return _des
            End Get
            Set(ByVal _des_value As String)
                _des = _des_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property label() As String
            Get
                Return _label
            End Get
            Set(ByVal _label_value As String)
                _label = _label_value
            End Set
        End Property

        Public Property t() As String
            Get
                Return _t
            End Get
            Set(ByVal _t_value As String)
                _t = _t_value
            End Set
        End Property

        Public Property v() As Integer
            Get
                Return _v
            End Get
            Set(ByVal _v_value As Integer)
                _v = _v_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class Contact

        Private _description As String
        Private _duty As String
        Private _email As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _location_identify As Integer
        Private _mobile_phone As String
        Private _name As String
        Private _organization_identify As Integer
        Private _phone As String
        Private _picture As String
        Private _qq As String
        Private _weixin As String

        Public Const TABLE_NAME As String = "Contact"

        Public Const C__IDENTIFY As String = "__Identify"
        Public Const C__ISDELETED As String = "_IsDeleted"
        Public Const C_DESCRIPTION As String = "description"
        Public Const C_DUTY As String = "duty"
        Public Const C_EMAIL As String = "email"
        Public Const C_LOCATION_IDENTIFY As String = "location_identify"
        Public Const C_MOBILE_PHONE As String = "mobile_phone"
        Public Const C_NAME As String = "name"
        Public Const C_ORGANIZATION_IDENTIFY As String = "organization_identify"
        Public Const C_PHONE As String = "phone"
        Public Const C_PICTURE As String = "picture"
        Public Const C_QQ As String = "qq"
        Public Const C_WEIXIN As String = "weixin"

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property duty() As String
            Get
                Return _duty
            End Get
            Set(ByVal _duty_value As String)
                _duty = _duty_value
            End Set
        End Property

        Public Property email() As String
            Get
                Return _email
            End Get
            Set(ByVal _email_value As String)
                _email = _email_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property location_identify() As Integer
            Get
                Return _location_identify
            End Get
            Set(ByVal _location_identify_value As Integer)
                _location_identify = _location_identify_value
            End Set
        End Property

        Public Property mobile_phone() As String
            Get
                Return _mobile_phone
            End Get
            Set(ByVal _mobile_phone_value As String)
                _mobile_phone = _mobile_phone_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property organization_identify() As Integer
            Get
                Return _organization_identify
            End Get
            Set(ByVal _organization_identify_value As Integer)
                _organization_identify = _organization_identify_value
            End Set
        End Property

        Public Property phone() As String
            Get
                Return _phone
            End Get
            Set(ByVal _phone_value As String)
                _phone = _phone_value
            End Set
        End Property

        Public Property picture() As String
            Get
                Return _picture
            End Get
            Set(ByVal _picture_value As String)
                _picture = _picture_value
            End Set
        End Property

        Public Property qq() As String
            Get
                Return _qq
            End Get
            Set(ByVal _qq_value As String)
                _qq = _qq_value
            End Set
        End Property

        Public Property weixin() As String
            Get
                Return _weixin
            End Get
            Set(ByVal _weixin_value As String)
                _weixin = _weixin_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class Documents

        Private _code_document_status As Integer
        Private _code_document_tyype As Integer
        Private _description As String
        Private _finalclass As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _name As String
        Private _obsolescence_date As Date
        Private _version As String

        Public Const TABLE_NAME As String = "Documents"

        Public Const C_CODE_DOCUMENT_STATUS As String = "code_document_status"
        Public Const C_CODE_DOCUMENT_TYYPE As String = "code_document_tyype"
        Public Const C_DESCRIPTION As String = "description"
        Public Const C_FINALCLASS As String = "finalclass"
        Public Const C_NAME As String = "name"
        Public Const C_OBSOLESCENCE_DATE As String = "obsolescence_date"
        Public Const C_VERSION As String = "version"

        Public Property code_document_status() As Integer
            Get
                Return _code_document_status
            End Get
            Set(ByVal _code_document_status_value As Integer)
                _code_document_status = _code_document_status_value
            End Set
        End Property

        Public Property code_document_tyype() As Integer
            Get
                Return _code_document_tyype
            End Get
            Set(ByVal _code_document_tyype_value As Integer)
                _code_document_tyype = _code_document_tyype_value
            End Set
        End Property

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property finalclass() As String
            Get
                Return _finalclass
            End Get
            Set(ByVal _finalclass_value As String)
                _finalclass = _finalclass_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property obsolescence_date() As Date
            Get
                Return _obsolescence_date
            End Get
            Set(ByVal _obsolescence_date_value As Date)
                _obsolescence_date = _obsolescence_date_value
            End Set
        End Property

        Public Property version() As String
            Get
                Return _version
            End Get
            Set(ByVal _version_value As String)
                _version = _version_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class DNSObject

        Private _comment As String
        Private _finalclass As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _name As String
        Private _organization_identify As Integer

        Public Const TABLE_NAME As String = "DNSObject"

        Public Const C_COMMENT As String = "comment"
        Public Const C_FINALCLASS As String = "finalclass"
        Public Const C_NAME As String = "name"
        Public Const C_ORGANIZATION_IDENTIFY As String = "organization_identify"

        Public Property comment() As String
            Get
                Return _comment
            End Get
            Set(ByVal _comment_value As String)
                _comment = _comment_value
            End Set
        End Property

        Public Property finalclass() As String
            Get
                Return _finalclass
            End Get
            Set(ByVal _finalclass_value As String)
                _finalclass = _finalclass_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property organization_identify() As Integer
            Get
                Return _organization_identify
            End Get
            Set(ByVal _organization_identify_value As Integer)
                _organization_identify = _organization_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class

    Public Class DomainQT : Inherits Domain
        ' 
    End Class

    Public Class Domain : Inherits DNSObject
        Private _code_renewal As Integer
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _parent_identify As Integer
        Private _registrar_identify As Integer
        Private _release_date As Date
        Private _requestor_identify As Integer
        Private _validity_end As Date
        Private _validity_start As Date

        Public Shadows Const TABLE_NAME As String = "Domain"

        Public Const C_CODE_RENEWAL As String = "code_renewal"
        Public Const C_ID As String = "id"
        Public Const C_PARENT_IDENTIFY As String = "parent_identify"
        Public Const C_REGISTRAR_IDENTIFY As String = "registrar_identify"
        Public Const C_RELEASE_DATE As String = "release_date"
        Public Const C_REQUESTOR_IDENTIFY As String = "requestor_identify"
        Public Const C_VALIDITY_END As String = "validity_end"
        Public Const C_VALIDITY_START As String = "validity_start"

        Public Property code_renewal() As Integer
            Get
                Return _code_renewal
            End Get
            Set(ByVal _code_renewal_value As Integer)
                _code_renewal = _code_renewal_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property parent_identify() As Integer
            Get
                Return _parent_identify
            End Get
            Set(ByVal _parent_identify_value As Integer)
                _parent_identify = _parent_identify_value
            End Set
        End Property

        Public Property registrar_identify() As Integer
            Get
                Return _registrar_identify
            End Get
            Set(ByVal _registrar_identify_value As Integer)
                _registrar_identify = _registrar_identify_value
            End Set
        End Property

        Public Property release_date() As Date
            Get
                Return _release_date
            End Get
            Set(ByVal _release_date_value As Date)
                _release_date = _release_date_value
            End Set
        End Property

        Public Property requestor_identify() As Integer
            Get
                Return _requestor_identify
            End Get
            Set(ByVal _requestor_identify_value As Integer)
                _requestor_identify = _requestor_identify_value
            End Set
        End Property

        Public Property validity_end() As Date
            Get
                Return _validity_end
            End Get
            Set(ByVal _validity_end_value As Date)
                _validity_end = _validity_end_value
            End Set
        End Property

        Public Property validity_start() As Date
            Get
                Return _validity_start
            End Get
            Set(ByVal _validity_start_value As Date)
                _validity_start = _validity_start_value
            End Set
        End Property

    End Class


    Public Class Location

        Private _city As String
        Private _country As String
        Private _description As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _name As String
        Private _organization_identify As Integer
        Private _status As Boolean

        Public Const TABLE_NAME As String = "Location"

        Public Const C_CITY As String = "city"
        Public Const C_COUNTRY As String = "country"
        Public Const C_DESCRIPTION As String = "description"
        Public Const C_NAME As String = "name"
        Public Const C_ORGANIZATION_IDENTIFY As String = "organization_identify"
        Public Const C_STATUS As String = "status"

        Public Property city() As String
            Get
                Return _city
            End Get
            Set(ByVal _city_value As String)
                _city = _city_value
            End Set
        End Property

        Public Property country() As String
            Get
                Return _country
            End Get
            Set(ByVal _country_value As String)
                _country = _country_value
            End Set
        End Property

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property organization_identify() As Integer
            Get
                Return _organization_identify
            End Get
            Set(ByVal _organization_identify_value As Integer)
                _organization_identify = _organization_identify_value
            End Set
        End Property

        Public Property status() As Boolean
            Get
                Return _status
            End Get
            Set(ByVal _status_value As Boolean)
                _status = _status_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LogicalVolume

        Private _description As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _lun_id As String
        Private _name As String
        Private _obsolescence_date As Date
        Private _raid_level As String
        Private _size As String
        Private _storagesystem_identify As Integer

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property lun_id() As String
            Get
                Return _lun_id
            End Get
            Set(ByVal _lun_id_value As String)
                _lun_id = _lun_id_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property obsolescence_date() As Date
            Get
                Return _obsolescence_date
            End Get
            Set(ByVal _obsolescence_date_value As Date)
                _obsolescence_date = _obsolescence_date_value
            End Set
        End Property

        Public Property raid_level() As String
            Get
                Return _raid_level
            End Get
            Set(ByVal _raid_level_value As String)
                _raid_level = _raid_level_value
            End Set
        End Property

        Public Property size() As String
            Get
                Return _size
            End Get
            Set(ByVal _size_value As String)
                _size = _size_value
            End Set
        End Property

        Public Property storagesystem_identify() As Integer
            Get
                Return _storagesystem_identify
            End Get
            Set(ByVal _storagesystem_identify_value As Integer)
                _storagesystem_identify = _storagesystem_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class Organization

        Private __Identify As Integer
        Private _parent_identify As Integer
        Private _name As String
        Private _child_code As String
        Private _parent_code As String
        Private _status As Boolean
        Private _code_org_type As Integer
        Private _short_name As String
        Private _description As String
        Private __IsDeleted As Boolean
        Private __sort As Decimal

        Public Const TABLE_NAME As String = "Organization"

        Public Const C__IDENTIFY As String = "_Identify"
        Public Const C__SORT As String = "_sort"
        Public Const C_CODE As String = "code"
        Public Const C__CODE As String = "_code"
        Public Const C_NAME As String = "name"
        Public Const C_STATUS As String = "status"
        Public Const C_PARENT_IDENTIFY As String = "parent_identify"
        Public Const C_DESCRIPTION As String = "description"
        Public Const C_SHORT_NAME As String = "short_name"
        Public Const C_CODE_ORG_TYPE As String = "code_org_type"
        Public Const C__ISDELETED As String = "_IsDeleted"

        Public Property _code() As String
            Get
                Return _parent_code
            End Get
            Set(ByVal _parent_code_value As String)
                _parent_code = _parent_code_value
            End Set
        End Property

        Public Property _sort() As Decimal
            Get
                Return __sort
            End Get
            Set(ByVal __sort_value As Decimal)
                __sort = __sort_value
            End Set
        End Property

        Public Property code() As String
            Get
                Return _child_code
            End Get
            Set(ByVal _code_value As String)
                _child_code = _code_value
            End Set
        End Property

        Public Property code_org_type() As Integer
            Get
                Return _code_org_type
            End Get
            Set(ByVal _code_org_type_value As Integer)
                _code_org_type = _code_org_type_value
            End Set
        End Property

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property parent_identify() As Integer
            Get
                Return _parent_identify
            End Get
            Set(ByVal _parent_identify_value As Integer)
                _parent_identify = _parent_identify_value
            End Set
        End Property

        Public Property short_name() As String
            Get
                Return _short_name
            End Get
            Set(ByVal _short_name_value As String)
                _short_name = _short_name_value
            End Set
        End Property

        Public Property status() As Boolean
            Get
                Return _status
            End Get
            Set(ByVal _status_value As Boolean)
                _status = _status_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class Passwd

        Private __use As String
        Private _account As String
        Private _end_date As Date
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _passwd As String
        Private _start_date As Date

        Public Const TABLE_NAME As String = "Passwd"

        Public Const C__USE As String = "_use"
        Public Const C_ACCOUNT As String = "account"
        Public Const C_END_DATE As String = "end_date"
        Public Const C_PASSWD As String = "passwd"
        Public Const C_START_DATE As String = "start_date"

        Public Property _use() As String
            Get
                Return __use
            End Get
            Set(ByVal __use_value As String)
                __use = __use_value
            End Set
        End Property

        Public Property account() As String
            Get
                Return _account
            End Get
            Set(ByVal _account_value As String)
                _account = _account_value
            End Set
        End Property

        Public Property end_date() As Date
            Get
                Return _end_date
            End Get
            Set(ByVal _end_date_value As Date)
                _end_date = _end_date_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property passwd() As String
            Get
                Return _passwd
            End Get
            Set(ByVal _passwd_value As String)
                _passwd = _passwd_value
            End Set
        End Property

        Public Property start_date() As Date
            Get
                Return _start_date
            End Get
            Set(ByVal _start_date_value As Date)
                _start_date = _start_date_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class SecurityStrategy

        Private _code_security_strategy_type As Integer
        Private _config_port_identify As Integer
        Private _description As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _name As String
        Private _physical_device_identify As Integer

        Public Const TABLE_NAME As String = "SecurityStrategy"

        Public Const C_CODE_SECURITY_STRATEGY_TYPE As String = "code_security_strategy_type"
        Public Const C_CONFIG_PORT_IDENTIFY As String = "config_port_identify"
        Public Const C_DESCRIPTION As String = "description"
        Public Const C_NAME As String = "name"
        Public Const C_PHYSICAL_DEVICE_IDENTIFY As String = "physical_device_identify"

        Public Property code_security_strategy_type() As Integer
            Get
                Return _code_security_strategy_type
            End Get
            Set(ByVal _code_security_strategy_type_value As Integer)
                _code_security_strategy_type = _code_security_strategy_type_value
            End Set
        End Property

        Public Property config_port_identify() As Integer
            Get
                Return _config_port_identify
            End Get
            Set(ByVal _config_port_identify_value As Integer)
                _config_port_identify = _config_port_identify_value
            End Set
        End Property

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property physical_device_identify() As Integer
            Get
                Return _physical_device_identify
            End Get
            Set(ByVal _physical_device_identify_value As Integer)
                _physical_device_identify = _physical_device_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class Software

        Private _code_software_type As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _name As String
        Private _vendor As String
        Private _version As String

        Public Const TABLE_NAME As String = "Software"

        Public Const C_CODE_SOFTWARE_TYPE As String = "code_software_type"
        Public Const C_NAME As String = "name"
        Public Const C_VENDOR As String = "vendor"
        Public Const C_VERSION As String = "version"

        Public Property code_software_type() As Integer
            Get
                Return _code_software_type
            End Get
            Set(ByVal _code_software_type_value As Integer)
                _code_software_type = _code_software_type_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property vendor() As String
            Get
                Return _vendor
            End Get
            Set(ByVal _vendor_value As String)
                _vendor = _vendor_value
            End Set
        End Property

        Public Property version() As String
            Get
                Return _version
            End Get
            Set(ByVal _version_value As String)
                _version = _version_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class VLAN

        Private _description As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _organization_identify As Integer
        Private _vlan_tag As String

        Public Const TABLE_NAME As String = "VLAN"

        Public Const C_DESCRIPTION As String = "description"
        Public Const C_ORGANIZATION_IDENTIFY As String = "organization_identify"
        Public Const C_VLAN_TAG As String = "vlan_tag"

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property organization_identify() As Integer
            Get
                Return _organization_identify
            End Get
            Set(ByVal _organization_identify_value As Integer)
                _organization_identify = _organization_identify_value
            End Set
        End Property

        Public Property vlan_tag() As String
            Get
                Return _vlan_tag
            End Get
            Set(ByVal _vlan_tag_value As String)
                _vlan_tag = _vlan_tag_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    ' ------------------------------

    ' Change * 

    Public Class Change

        Private _code_origin As Integer
        Private _date As Date
        Private __Identify As Integer
        Private _user_name As String

        Public Const TABLE_NAME As String = "Change"

        Public Const C__IDENTIFY As String = "__Identify"
        Public Const C_CODE_ORIGIN As String = "code_origin"
        Public Const C_DATE As String = "date"
        Public Const C_USER_NAME As String = "user_name"

        Public Property code_origin() As Integer
            Get
                Return _code_origin
            End Get
            Set(ByVal _code_origin_value As Integer)
                _code_origin = _code_origin_value
            End Set
        End Property

        Public Property change_date() As Date
            Get
                Return _date
            End Get
            Set(ByVal _date_value As Date)
                _date = _date_value
            End Set
        End Property

        Public Property user_name() As String
            Get
                Return _user_name
            End Get
            Set(ByVal _user_name_value As String)
                _user_name = _user_name_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class ChangeOp

        Private _change_identify As Integer
        Private __Identify As Integer
        Private _objclass As String
        Private _objkey As Integer
        Private _optype As String

        Public Const TABLE_NAME As String = "ChangeOp"

        Public Const C__IDENTIFY As String = "__Identify"
        Public Const C_CHANGE_IDENTIFY As String = "change_identify"
        Public Const C_OBJCLASS As String = "objclass"
        Public Const C_OBJKEY As String = "objkey"
        Public Const C_OPTYPE As String = "optype"

        Public Property change_identify() As Integer
            Get
                Return _change_identify
            End Get
            Set(ByVal _change_identify_value As Integer)
                _change_identify = _change_identify_value
            End Set
        End Property

        Public Property objclass() As String
            Get
                Return _objclass
            End Get
            Set(ByVal _objclass_value As String)
                _objclass = _objclass_value
            End Set
        End Property

        Public Property objkey() As Integer
            Get
                Return _objkey
            End Get
            Set(ByVal _objkey_value As Integer)
                _objkey = _objkey_value
            End Set
        End Property

        Public Property optype() As String
            Get
                Return _optype
            End Get
            Set(ByVal _optype_value As String)
                _optype = _optype_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class ChangeOpCreate : Inherits ChangeOp
        Private _id As Integer

        Public Shadows Const TABLE_NAME As String = "ChangeOpCreate"

        Public Const C_ID As String = "id"

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

    End Class


    Public Class ChangeOpDelete : Inherits ChangeOp
        Private _fclass As String
        Private _fname As String
        Private _id As Integer

        Public Shadows Const TABLE_NAME As String = "ChangeOpDelete"

        Public Const C_FCLASS As String = "fclass"
        Public Const C_FNAME As String = "fname"
        Public Const C_ID As String = "id"

        Public Property fclass() As String
            Get
                Return _fclass
            End Get
            Set(ByVal _fclass_value As String)
                _fclass = _fclass_value
            End Set
        End Property

        Public Property fname() As String
            Get
                Return _fname
            End Get
            Set(ByVal _fname_value As String)
                _fname = _fname_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

    End Class


    Public Class ChangeOpLinks : Inherits ChangeOp
        Private _id As Integer
        Private _item_class As String
        Private _item_identify As Integer

        Public Shadows Const TABLE_NAME As String = "ChangeOpLinks"

        Public Const C_ID As String = "id"
        Public Const C_ITEM_CLASS As String = "item_class"
        Public Const C_ITEM_IDENTIFY As String = "item_identify"

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Property item_class() As String
            Get
                Return _item_class
            End Get
            Set(ByVal _item_class_value As String)
                _item_class = _item_class_value
            End Set
        End Property

        Public Property item_identify() As Integer
            Get
                Return _item_identify
            End Get
            Set(ByVal _item_identify_value As Integer)
                _item_identify = _item_identify_value
            End Set
        End Property

    End Class


    Public Class ChangeOpLinksAddRemove : Inherits ChangeOpLinks
        Private _id As Integer
        Private _type As String

        Public Shadows Const TABLE_NAME As String = "ChangeOpLinksAddRemove"

        Public Shadows Const C_ID As String = "id"
        Public Const C_TYPE As String = "type"

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Property type() As String
            Get
                Return _type
            End Get
            Set(ByVal _type_value As String)
                _type = _type_value
            End Set
        End Property

    End Class


    Public Class ChangeOpSetAtt : Inherits ChangeOp
        Private _attcode As String
        Private _id As Integer

        Public Shadows Const TABLE_NAME As String = "ChangeOpSetAtt"

        Public Const C_ATTCODE As String = "attcode"
        Public Const C_ID As String = "id"

        Public Property attcode() As String
            Get
                Return _attcode
            End Get
            Set(ByVal _attcode_value As String)
                _attcode = _attcode_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

    End Class


    Public Class ChangeOpSetAttPwd : Inherits ChangeOpSetAtt
        Private _id As Integer
        Private _prev_pwd_hash As String
        Private _prev_pwd_salt As String

        Public Shadows Const TABLE_NAME As String = "ChangeOpSetAttPwd"

        Public Shadows Const C_ID As String = "id"
        Public Const C_PREV_PWD_HASH As String = "prev_pwd_hash"
        Public Const C_PREV_PWD_SALT As String = "prev_pwd_salt"

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Property prev_pwd_hash() As String
            Get
                Return _prev_pwd_hash
            End Get
            Set(ByVal _prev_pwd_hash_value As String)
                _prev_pwd_hash = _prev_pwd_hash_value
            End Set
        End Property

        Public Property prev_pwd_salt() As String
            Get
                Return _prev_pwd_salt
            End Get
            Set(ByVal _prev_pwd_salt_value As String)
                _prev_pwd_salt = _prev_pwd_salt_value
            End Set
        End Property

    End Class


    Public Class ChangeOpSetAttScalar : Inherits ChangeOpSetAtt
        Private _id As Integer
        Private _newvalue As String
        Private _oldvalue As String

        Public Shadows Const TABLE_NAME As String = "ChangeOpSetAttScalar"

        Public Shadows Const C_ID As String = "id"
        Public Const C_NEWVALUE As String = "newvalue"
        Public Const C_OLDVALUE As String = "oldvalue"

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Property newvalue() As String
            Get
                Return _newvalue
            End Get
            Set(ByVal _newvalue_value As String)
                _newvalue = _newvalue_value
            End Set
        End Property

        Public Property oldvalue() As String
            Get
                Return _oldvalue
            End Get
            Set(ByVal _oldvalue_value As String)
                _oldvalue = _oldvalue_value
            End Set
        End Property

    End Class


    Public Class ChangeOpSetAttText : Inherits ChangeOpSetAtt
        Private _id As Integer
        Private _newvalue As String
        Private _oldvalue As String

        Public Shadows Const TABLE_NAME As String = "ChangeOpSetAttText"

        Public Shadows Const C_ID As String = "id"
        Public Const C_NEWVALUE As String = "newvalue"
        Public Const C_OLDVALUE As String = "oldvalue"

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Property newvalue() As String
            Get
                Return _newvalue
            End Get
            Set(ByVal _newvalue_value As String)
                _newvalue = _newvalue_value
            End Set
        End Property

        Public Property oldvalue() As String
            Get
                Return _oldvalue
            End Get
            Set(ByVal _oldvalue_value As String)
                _oldvalue = _oldvalue_value
            End Set
        End Property

    End Class


    Public Class ChangeOpSetAttUrl : Inherits ChangeOpSetAtt
        Private _id As Integer
        Private _newvalue As String
        Private _oldvalue As String

        Public Shadows Const TABLE_NAME As String = "ChangeOpSetAttUrl"

        Public Shadows Const C_ID As String = "id"
        Public Const C_NEWVALUE As String = "newvalue"
        Public Const C_OLDVALUE As String = "oldvalue"

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Property newvalue() As String
            Get
                Return _newvalue
            End Get
            Set(ByVal _newvalue_value As String)
                _newvalue = _newvalue_value
            End Set
        End Property

        Public Property oldvalue() As String
            Get
                Return _oldvalue
            End Get
            Set(ByVal _oldvalue_value As String)
                _oldvalue = _oldvalue_value
            End Set
        End Property

    End Class

    ' ------------------------------

    ' Contract *

    Public Class Contract

        Private _billing_frequency As String
        Private _buyer_agent_identify As Integer
        Private _buyer_identify As Integer
        Private _code As String
        Private _cost As Decimal
        Private _cost_currency As String
        Private _cost_unit As String
        Private _end_date As Date
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _name As String
        Private _seller_agent_identify As Integer
        Private _seller_identify As Integer
        Private _start_date As Date
        Private _status As String
        Private _type As String
        Private _finalclass As String

        Public Property finalclass() As String
            Get
                Return _finalclass
            End Get
            Set(ByVal _finalclass_value As String)
                _finalclass = _finalclass_value
            End Set
        End Property

        Public Property billing_frequency() As String
            Get
                Return _billing_frequency
            End Get
            Set(ByVal _billing_frequency_value As String)
                _billing_frequency = _billing_frequency_value
            End Set
        End Property

        Public Property buyer_agent_identify() As Integer
            Get
                Return _buyer_agent_identify
            End Get
            Set(ByVal _buyer_agent_identify_value As Integer)
                _buyer_agent_identify = _buyer_agent_identify_value
            End Set
        End Property

        Public Property buyer_identify() As Integer
            Get
                Return _buyer_identify
            End Get
            Set(ByVal _buyer_identify_value As Integer)
                _buyer_identify = _buyer_identify_value
            End Set
        End Property

        Public Property code() As String
            Get
                Return _code
            End Get
            Set(ByVal _code_value As String)
                _code = _code_value
            End Set
        End Property

        Public Property cost() As Decimal
            Get
                Return _cost
            End Get
            Set(ByVal _cost_value As Decimal)
                _cost = _cost_value
            End Set
        End Property

        Public Property cost_currency() As String
            Get
                Return _cost_currency
            End Get
            Set(ByVal _cost_currency_value As String)
                _cost_currency = _cost_currency_value
            End Set
        End Property

        Public Property cost_unit() As String
            Get
                Return _cost_unit
            End Get
            Set(ByVal _cost_unit_value As String)
                _cost_unit = _cost_unit_value
            End Set
        End Property

        Public Property end_date() As Date
            Get
                Return _end_date
            End Get
            Set(ByVal _end_date_value As Date)
                _end_date = _end_date_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property seller_agent_identify() As Integer
            Get
                Return _seller_agent_identify
            End Get
            Set(ByVal _seller_agent_identify_value As Integer)
                _seller_agent_identify = _seller_agent_identify_value
            End Set
        End Property

        Public Property seller_identify() As Integer
            Get
                Return _seller_identify
            End Get
            Set(ByVal _seller_identify_value As Integer)
                _seller_identify = _seller_identify_value
            End Set
        End Property

        Public Property start_date() As Date
            Get
                Return _start_date
            End Get
            Set(ByVal _start_date_value As Date)
                _start_date = _start_date_value
            End Set
        End Property

        Public Property status() As String
            Get
                Return _status
            End Get
            Set(ByVal _status_value As String)
                _status = _status_value
            End Set
        End Property

        Public Property type() As String
            Get
                Return _type
            End Get
            Set(ByVal _type_value As String)
                _type = _type_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class ContractDetail

        Private _amount As Integer
        Private _contract_identify As Integer
        Private _description As String
        Private _end_of_warranty As Date
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _manufacturer As String
        Private _model As String
        Private _name As String
        Private _no As Integer
        Private _price As Decimal
        Private _purchase_date As Date

        Public Const TABLE_NAME As String = "ContractDetail"

        Public Const C_AMOUNT As String = "amount"
        Public Const C_CONTRACT_IDENTIFY As String = "contract_identify"
        Public Const C_DESCRIPTION As String = "description"
        Public Const C_END_OF_WARRANTY As String = "end_of_warranty"
        Public Const C_MANUFACTURER As String = "manufacturer"
        Public Const C_MODEL As String = "model"
        Public Const C_NAME As String = "name"
        Public Const C_NO As String = "no"
        Public Const C_PRICE As String = "price"
        Public Const C_PURCHASE_DATE As String = "purchase_date"

        Public Property amount() As Integer
            Get
                Return _amount
            End Get
            Set(ByVal _amount_value As Integer)
                _amount = _amount_value
            End Set
        End Property

        Public Property contract_identify() As Integer
            Get
                Return _contract_identify
            End Get
            Set(ByVal _contract_identify_value As Integer)
                _contract_identify = _contract_identify_value
            End Set
        End Property

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property end_of_warranty() As Date
            Get
                Return _end_of_warranty
            End Get
            Set(ByVal _end_of_warranty_value As Date)
                _end_of_warranty = _end_of_warranty_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property manufacturer() As String
            Get
                Return _manufacturer
            End Get
            Set(ByVal _manufacturer_value As String)
                _manufacturer = _manufacturer_value
            End Set
        End Property

        Public Property model() As String
            Get
                Return _model
            End Get
            Set(ByVal _model_value As String)
                _model = _model_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property no() As Integer
            Get
                Return _no
            End Get
            Set(ByVal _no_value As Integer)
                _no = _no_value
            End Set
        End Property

        Public Property price() As Decimal
            Get
                Return _price
            End Get
            Set(ByVal _price_value As Decimal)
                _price = _price_value
            End Set
        End Property

        Public Property purchase_date() As Date
            Get
                Return _purchase_date
            End Get
            Set(ByVal _purchase_date_value As Date)
                _purchase_date = _purchase_date_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class

    Public Class CustomerContractQT : Inherits CustomerContract
        ' 
    End Class

    Public Class CustomerContract : Inherits Contract
        Private _id As Integer
        Private __IsDeleted As Boolean

        Public Shadows Const TABLE_NAME As String = "CustomerContract"


        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

    End Class

    Public Class ProviderContractQT : Inherits ProviderContract
        ' 
    End Class

    Public Class ProviderContract : Inherits Contract
        Private _coverage As String
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _sla As String

        Public Shadows Const TABLE_NAME As String = "ProviderContract"

        Public Const C_COVERAGE As String = "coverage"
        Public Const C_SLA As String = "sla"

        Public Property coverage() As String
            Get
                Return _coverage
            End Get
            Set(ByVal _coverage_value As String)
                _coverage = _coverage_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property sla() As String
            Get
                Return _sla
            End Get
            Set(ByVal _sla_value As String)
                _sla = _sla_value
            End Set
        End Property

    End Class
    ' ------------------------------

    'FunctionalCI *
    Public Class FunctionalCI

        Private _code_risk_rating As Integer
        Private _description As String
        Private _finalclass As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _move2production As Date
        Private _name As String
        Private _obsolescence_date As Date

        Public Const TABLE_NAME As String = "FunctionalCI"

        Public Const C__IDENTIFY As String = "__Identify"
        Public Const C_NAME As String = "name"
        Public Const C_CODE_RISK_RATING As String = "code_risk_rating"
        Public Const C_DESCRIPTION As String = "description"
        Public Const C_MOVE2PRODUCTION As String = "move2production"
        Public Const C_OBSOLESCENCE_DATE As String = "obsolescence_date"
        Public Const C_FINALCLASS As String = "finalclass"
        Public Const C__ISDELETED As String = "_IsDeleted"

        Public Property code_risk_rating() As Integer
            Get
                Return _code_risk_rating
            End Get
            Set(ByVal _code_risk_rating_value As Integer)
                _code_risk_rating = _code_risk_rating_value
            End Set
        End Property

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property finalclass() As String
            Get
                Return _finalclass
            End Get
            Set(ByVal _finalclass_value As String)
                _finalclass = _finalclass_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property move2production() As Date
            Get
                Return _move2production
            End Get
            Set(ByVal _move2production_value As Date)
                _move2production = _move2production_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property obsolescence_date() As Date
            Get
                Return _obsolescence_date
            End Get
            Set(ByVal _obsolescence_date_value As Date)
                _obsolescence_date = _obsolescence_date_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class ApplicationSolutionQT : Inherits ApplicationSolution
        '简单继承，用于查询方法
    End Class

    Public Class ApplicationSolution : Inherits FunctionalCI
        Private _attention As String
        Private _code_application_status As Integer
        Private _code_sla As Integer
        Private _fault_effects As String
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _redundancy As String

        Public Shadows Const TABLE_NAME As String = "ApplicationSolution"

        Public Const C_ID As String = "id"
        Public Const C_CODE_APPLICATION_STATUS As String = "code_application_status"
        Public Const C_REDUNDANCY As String = "redundancy"
        Public Const C_CODE_SLA As String = "code_sla"
        Public Const C_FAULT_EFFECTS As String = "fault_effects"
        Public Const C_ATTENTION As String = "attention"
        Public Shadows Const C__ISDELETED As String = "_IsDeleted"

        Public Property attention() As String
            Get
                Return _attention
            End Get
            Set(ByVal _attention_value As String)
                _attention = _attention_value
            End Set
        End Property

        Public Property code_application_status() As Integer
            Get
                Return _code_application_status
            End Get
            Set(ByVal _code_application_status_value As Integer)
                _code_application_status = _code_application_status_value
            End Set
        End Property

        Public Property code_sla() As Integer
            Get
                Return _code_sla
            End Get
            Set(ByVal _code_sla_value As Integer)
                _code_sla = _code_sla_value
            End Set
        End Property

        Public Property fault_effects() As String
            Get
                Return _fault_effects
            End Get
            Set(ByVal _fault_effects_value As String)
                _fault_effects = _fault_effects_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property redundancy() As String
            Get
                Return _redundancy
            End Get
            Set(ByVal _redundancy_value As String)
                _redundancy = _redundancy_value
            End Set
        End Property

    End Class

    Public Class DatabasesSchemaQT : Inherits DatabasesSchema
        '
    End Class

    Public Class DatabasesSchema : Inherits FunctionalCI
        Private _comment As String
        Private _create_time As Date
        Private _dbserver_identify As Integer
        Private _farm_identify As Integer
        Private _id As Integer
        Private _individual As String
        Private __IsDeleted As Boolean
        Private _pdb_name As String

        Public Shadows Const TABLE_NAME As String = "DatabasesSchema"

        Public Const C_DBSERVER_IDENTIFY As String = "dbserver_identify"
        Public Const C_FARM_IDENTIFY As String = "farm_identify"
        Public Const C_PDB_NAME As String = "pdb_name"
        Public Const C_COMMENT As String = "comment"
        Public Const C_CREATE_TIME As String = "create_time"
        Public Const C_INDIVIDUAL As String = "individual"

        Public Property comment() As String
            Get
                Return _comment
            End Get
            Set(ByVal _comment_value As String)
                _comment = _comment_value
            End Set
        End Property

        Public Property create_time() As Date
            Get
                Return _create_time
            End Get
            Set(ByVal _create_time_value As Date)
                _create_time = _create_time_value
            End Set
        End Property

        Public Property dbserver_identify() As Integer
            Get
                Return _dbserver_identify
            End Get
            Set(ByVal _dbserver_identify_value As Integer)
                _dbserver_identify = _dbserver_identify_value
            End Set
        End Property

        Public Property farm_identify() As Integer
            Get
                Return _farm_identify
            End Get
            Set(ByVal _farm_identify_value As Integer)
                _farm_identify = _farm_identify_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Property individual() As String
            Get
                Return _individual
            End Get
            Set(ByVal _individual_value As String)
                _individual = _individual_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property pdb_name() As String
            Get
                Return _pdb_name
            End Get
            Set(ByVal _pdb_name_value As String)
                _pdb_name = _pdb_name_value
            End Set
        End Property

    End Class

    Public Class MiddlewareInstanceQT : Inherits MiddlewareInstance
        '
    End Class

    Public Class MiddlewareInstance : Inherits FunctionalCI
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _middleware_identify As Integer

        Public Shadows Const TABLE_NAME As String = "MiddlewareInstance"

        Public Const C_MIDDLEWARE_IDENTIFY As String = "middleware_identify"

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property middleware_identify() As Integer
            Get
                Return _middleware_identify
            End Get
            Set(ByVal _middleware_identify_value As Integer)
                _middleware_identify = _middleware_identify_value
            End Set
        End Property

    End Class

    Public Class WebApplicationQT : Inherits WebApplication
        Public Shadows Const TABLE_NAME As String = "WebApplicationQT"
    End Class

    Public Class WebApplication : Inherits FunctionalCI
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _url As String
        Private _webserver_identify As Integer

        Public Shadows Const TABLE_NAME As String = "WebApplication"

        Public Const C_URL As String = "url"
        Public Const C_WEBSERVER_IDENTIFY As String = "webserver_identify"

        Public Sub New()
            finalclass = TABLE_NAME
        End Sub

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property url() As String
            Get
                Return _url
            End Get
            Set(ByVal _url_value As String)
                _url = _url_value
            End Set
        End Property

        Public Property webserver_identify() As Integer
            Get
                Return _webserver_identify
            End Get
            Set(ByVal _webserver_identify_value As Integer)
                _webserver_identify = _webserver_identify_value
            End Set
        End Property

    End Class

    Public Class ConnectableCI : Inherits PhysicalDevice
        Private _id As Integer
        Private __IsDeleted As Boolean

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

    End Class

    Public Class PhysicalDevice : Inherits FunctionalCI
        Private _asset_number As String
        Private _code_brand_name As Integer
        Private _code_model_name As Integer
        Private _code_physicaldevice_status As Integer
        Private _end_of_warranty As Date
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _location_identify As Integer
        Private _purchase_date As Date
        Private _serialnumber As String

        Public Shadows Const TABLE_NAME As String = "PhysicalDevice"

        Public Const C_ASSET_NUMBER As String = "asset_number"
        Public Const C_CODE_BRAND_NAME As String = "code_brand_name"
        Public Const C_CODE_MODEL_NAME As String = "code_model_name"
        Public Const C_CODE_PHYSICALDEVICE_STATUS As String = "code_physicaldevice_status"
        Public Const C_END_OF_WARRANTY As String = "end_of_warranty"
        Public Const C_LOCATION_IDENTIFY As String = "location_identify"
        Public Const C_PURCHASE_DATE As String = "purchase_date"
        Public Const C_SERIALNUMBER As String = "serialnumber"

        Public Property asset_number() As String
            Get
                Return _asset_number
            End Get
            Set(ByVal _asset_number_value As String)
                _asset_number = _asset_number_value
            End Set
        End Property

        Public Property code_brand_name() As Integer
            Get
                Return _code_brand_name
            End Get
            Set(ByVal _code_brand_name_value As Integer)
                _code_brand_name = _code_brand_name_value
            End Set
        End Property

        Public Property code_model_name() As Integer
            Get
                Return _code_model_name
            End Get
            Set(ByVal _code_model_name_value As Integer)
                _code_model_name = _code_model_name_value
            End Set
        End Property

        Public Property code_physicaldevice_status() As Integer
            Get
                Return _code_physicaldevice_status
            End Get
            Set(ByVal _code_physicaldevice_status_value As Integer)
                _code_physicaldevice_status = _code_physicaldevice_status_value
            End Set
        End Property

        Public Property end_of_warranty() As Date
            Get
                Return _end_of_warranty
            End Get
            Set(ByVal _end_of_warranty_value As Date)
                _end_of_warranty = _end_of_warranty_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property location_identify() As Integer
            Get
                Return _location_identify
            End Get
            Set(ByVal _location_identify_value As Integer)
                _location_identify = _location_identify_value
            End Set
        End Property

        Public Property purchase_date() As Date
            Get
                Return _purchase_date
            End Get
            Set(ByVal _purchase_date_value As Date)
                _purchase_date = _purchase_date_value
            End Set
        End Property

        Public Property serialnumber() As String
            Get
                Return _serialnumber
            End Get
            Set(ByVal _serialnumber_value As String)
                _serialnumber = _serialnumber_value
            End Set
        End Property

    End Class


    Public Class VirtualDevice : Inherits FunctionalCI
        Private _code_virtualdevice_status As Integer
        Private _id As Integer
        Private __IsDeleted As Boolean

        Public Shadows Const TABLE_NAME As String = "VirtualDevice"

        Public Const C_CODE_VIRTUALDEVICE_STATUS As String = "code_virtualdevice_status"
        Public Const C_ID As String = "id"

        Public Property code_virtualdevice_status() As Integer
            Get
                Return _code_virtualdevice_status
            End Get
            Set(ByVal _code_virtualdevice_status_value As Integer)
                _code_virtualdevice_status = _code_virtualdevice_status_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

    End Class


    Public Class SoftwareInstance : Inherits FunctionalCI
        Private _functionalci_identify As Integer
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _path As String
        Private _software_identify As Integer
        Private _softwarelicence_identify As Integer
        Private _status As Boolean

        Public Shadows Const TABLE_NAME As String = "SoftwareInstance"

        Public Const C_FUNCTIONALCI_IDENTIFY As String = "functionalci_identify"
        Public Const C_PATH As String = "path"
        Public Const C_SOFTWARE_IDENTIFY As String = "software_identify"
        Public Const C_SOFTWARELICENCE_IDENTIFY As String = "softwarelicence_identify"
        Public Const C_STATUS As String = "status"

        Public Property functionalci_identify() As Integer
            Get
                Return _functionalci_identify
            End Get
            Set(ByVal _functionalci_identify_value As Integer)
                _functionalci_identify = _functionalci_identify_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property path() As String
            Get
                Return _path
            End Get
            Set(ByVal _path_value As String)
                _path = _path_value
            End Set
        End Property

        Public Property software_identify() As Integer
            Get
                Return _software_identify
            End Get
            Set(ByVal _software_identify_value As Integer)
                _software_identify = _software_identify_value
            End Set
        End Property

        Public Property softwarelicence_identify() As Integer
            Get
                Return _softwarelicence_identify
            End Get
            Set(ByVal _softwarelicence_identify_value As Integer)
                _softwarelicence_identify = _softwarelicence_identify_value
            End Set
        End Property

        Public Property status() As Boolean
            Get
                Return _status
            End Get
            Set(ByVal _status_value As Boolean)
                _status = _status_value
            End Set
        End Property

    End Class


    Public Class WANLink : Inherits FunctionalCI
        Private _burst_rate As String
        Private _carrier_identify As Integer
        Private _code_wanlink_status As Integer
        Private _code_wanlink_type As Integer
        Private _decommissioning_date As Date
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _location_identify1 As Integer
        Private _location_identify2 As Integer
        Private _networkinterface_identify1 As Integer
        Private _networkinterface_identify2 As Integer
        Private _purchase_date As Date
        Private _rate As String
        Private _renewal_date As Date
        Private _underlying_rate As String

        Public Shadows Const TABLE_NAME As String = "WANLink"

        Public Const C_BURST_RATE As String = "burst_rate"
        Public Const C_CARRIER_IDENTIFY As String = "carrier_identify"
        Public Const C_CODE_WANLINK_STATUS As String = "code_wanlink_status"
        Public Const C_CODE_WANLINK_TYPE As String = "code_wanlink_type"
        Public Const C_DECOMMISSIONING_DATE As String = "decommissioning_date"
        Public Const C_LOCATION_IDENTIFY1 As String = "location_identify1"
        Public Const C_LOCATION_IDENTIFY2 As String = "location_identify2"
        Public Const C_NETWORKINTERFACE_IDENTIFY1 As String = "networkinterface_identify1"
        Public Const C_NETWORKINTERFACE_IDENTIFY2 As String = "networkinterface_identify2"
        Public Const C_PURCHASE_DATE As String = "purchase_date"
        Public Const C_RATE As String = "rate"
        Public Const C_RENEWAL_DATE As String = "renewal_date"
        Public Const C_UNDERLYING_RATE As String = "underlying_rate"

        Public Property burst_rate() As String
            Get
                Return _burst_rate
            End Get
            Set(ByVal _burst_rate_value As String)
                _burst_rate = _burst_rate_value
            End Set
        End Property

        Public Property carrier_identify() As Integer
            Get
                Return _carrier_identify
            End Get
            Set(ByVal _carrier_identify_value As Integer)
                _carrier_identify = _carrier_identify_value
            End Set
        End Property

        Public Property code_wanlink_status() As Integer
            Get
                Return _code_wanlink_status
            End Get
            Set(ByVal _code_wanlink_status_value As Integer)
                _code_wanlink_status = _code_wanlink_status_value
            End Set
        End Property

        Public Property code_wanlink_type() As Integer
            Get
                Return _code_wanlink_type
            End Get
            Set(ByVal _code_wanlink_type_value As Integer)
                _code_wanlink_type = _code_wanlink_type_value
            End Set
        End Property

        Public Property decommissioning_date() As Date
            Get
                Return _decommissioning_date
            End Get
            Set(ByVal _decommissioning_date_value As Date)
                _decommissioning_date = _decommissioning_date_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property location_identify1() As Integer
            Get
                Return _location_identify1
            End Get
            Set(ByVal _location_identify1_value As Integer)
                _location_identify1 = _location_identify1_value
            End Set
        End Property

        Public Property location_identify2() As Integer
            Get
                Return _location_identify2
            End Get
            Set(ByVal _location_identify2_value As Integer)
                _location_identify2 = _location_identify2_value
            End Set
        End Property

        Public Property networkinterface_identify1() As Integer
            Get
                Return _networkinterface_identify1
            End Get
            Set(ByVal _networkinterface_identify1_value As Integer)
                _networkinterface_identify1 = _networkinterface_identify1_value
            End Set
        End Property

        Public Property networkinterface_identify2() As Integer
            Get
                Return _networkinterface_identify2
            End Get
            Set(ByVal _networkinterface_identify2_value As Integer)
                _networkinterface_identify2 = _networkinterface_identify2_value
            End Set
        End Property

        Public Property purchase_date() As Date
            Get
                Return _purchase_date
            End Get
            Set(ByVal _purchase_date_value As Date)
                _purchase_date = _purchase_date_value
            End Set
        End Property

        Public Property rate() As String
            Get
                Return _rate
            End Get
            Set(ByVal _rate_value As String)
                _rate = _rate_value
            End Set
        End Property

        Public Property renewal_date() As Date
            Get
                Return _renewal_date
            End Get
            Set(ByVal _renewal_date_value As Date)
                _renewal_date = _renewal_date_value
            End Set
        End Property

        Public Property underlying_rate() As String
            Get
                Return _underlying_rate
            End Get
            Set(ByVal _underlying_rate_value As String)
                _underlying_rate = _underlying_rate_value
            End Set
        End Property

    End Class

    ' ------------------------------
    ' PhysicalDevice*

    Public Class RackQT : Inherits Rack
        '
    End Class

    Public Class Rack : Inherits PhysicalDevice
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _nb_u As Integer

        Public Shadows Const TABLE_NAME As String = "Rack"

        Public Const C_NB_U As String = "nb_u"

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property nb_u() As Integer
            Get
                Return _nb_u
            End Get
            Set(ByVal _nb_u_value As Integer)
                _nb_u = _nb_u_value
            End Set
        End Property

    End Class

    Public Class EnclosureQT : Inherits Enclosure
        ' 
    End Class

    Public Class Enclosure : Inherits PhysicalDevice
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _nb_u As String
        Private _rack_identify As Integer

        Public Shadows Const TABLE_NAME As String = "Enclosure"

        Public Const C_NB_U As String = "nb_u"
        Public Const C_RACK_IDENTIFY As String = "rack_identify"

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property nb_u() As String
            Get
                Return _nb_u
            End Get
            Set(ByVal _nb_u_value As String)
                _nb_u = _nb_u_value
            End Set
        End Property

        Public Property rack_identify() As Integer
            Get
                Return _rack_identify
            End Get
            Set(ByVal _rack_identify_value As Integer)
                _rack_identify = _rack_identify_value
            End Set
        End Property

    End Class

    Public Class PeripheralQT : Inherits Peripheral
        ' 
    End Class

    Public Class Peripheral : Inherits PhysicalDevice
        Private _id As Integer
        Private __IsDeleted As Boolean

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

    End Class





    Public Class DataCenterDevice : Inherits ConnectableCI
        Private _enclosure_identity As Integer
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _managementip As Integer
        Private _nb_u As Integer
        Private _rack_identify As Integer
        Private _redundancy As String

        Public Shadows Const TABLE_NAME As String = "DataCenterDevice"

        Public Const C_RACK_IDENTIFY As String = "rack_identify"
        Public Const C_ENCLOSURE_IDENTITY As String = "enclosure_identity"
        Public Const C_MANAGEMENTIP As String = "managementip"
        Public Const C_NB_U As String = "nb_u"
        Public Const C_REDUNDANCY As String = "redundancy"

        Public Property enclosure_identity() As Integer
            Get
                Return _enclosure_identity
            End Get
            Set(ByVal _enclosure_identity_value As Integer)
                _enclosure_identity = _enclosure_identity_value
            End Set
        End Property

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property managementip() As Integer
            Get
                Return _managementip
            End Get
            Set(ByVal _managementip_value As Integer)
                _managementip = _managementip_value
            End Set
        End Property

        Public Property nb_u() As Integer
            Get
                Return _nb_u
            End Get
            Set(ByVal _nb_u_value As Integer)
                _nb_u = _nb_u_value
            End Set
        End Property

        Public Property rack_identify() As Integer
            Get
                Return _rack_identify
            End Get
            Set(ByVal _rack_identify_value As Integer)
                _rack_identify = _rack_identify_value
            End Set
        End Property

        Public Property redundancy() As String
            Get
                Return _redundancy
            End Get
            Set(ByVal _redundancy_value As String)
                _redundancy = _redundancy_value
            End Set
        End Property

    End Class

    Public Class SANSwitchQT : Inherits SANSwitch
        ' 
    End Class

    Public Class SANSwitch : Inherits DataCenterDevice
        Private _id As Integer
        Private __IsDeleted As Boolean


        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

    End Class

    Public Class NASQT : Inherits NAS
        '
    End Class

    Public Class NAS : Inherits DataCenterDevice
        Private _id As Integer
        Private __IsDeleted As Boolean

        Public Shadows Const TABLE_NAME As String = "NAS"

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

    End Class

    Public Class StorageSystemQT : Inherits StorageSystem
        ' 
    End Class

    Public Class StorageSystem : Inherits DataCenterDevice
        Private _code_storage_type As Integer
        Private _disk_path As String
        Private _disk_size As Decimal
        Private _id As Integer
        Private __IsDeleted As Boolean

        Public Shadows Const TABLE_NAME As String = "StorageSystem"

        Public Const C_CODE_STORAGE_TYPE As String = "code_storage_type"
        Public Const C_DISK_PATH As String = "disk_path"
        Public Const C_DISK_SIZE As String = "disk_size"

        Public Property code_storage_type() As Integer
            Get
                Return _code_storage_type
            End Get
            Set(ByVal _code_storage_type_value As Integer)
                _code_storage_type = _code_storage_type_value
            End Set
        End Property

        Public Property disk_path() As String
            Get
                Return _disk_path
            End Get
            Set(ByVal _disk_path_value As String)
                _disk_path = _disk_path_value
            End Set
        End Property

        Public Property disk_size() As Decimal
            Get
                Return _disk_size
            End Get
            Set(ByVal _disk_size_value As Decimal)
                _disk_size = _disk_size_value
            End Set
        End Property

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

    End Class

    Public Class ServerQT : Inherits Server
        '
    End Class

    Public Class Server : Inherits DataCenterDevice
        Private _cpu As String
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _osfamily_id As Integer
        Private _oslicence_id As Integer
        Private _osversion_id As Integer
        Private _ram As String

        Public Shadows Const TABLE_NAME As String = "Server"

        Public Const C_OSFAMILY_ID As String = "osfamily_id"
        Public Const C_OSLICENCE_ID As String = "oslicence_id"
        Public Const C_OSVERSION_ID As String = "osversion_id"
        Public Const C_CPU As String = "cpu"
        Public Const C_RAM As String = "ram"

        Public Property cpu() As String
            Get
                Return _cpu
            End Get
            Set(ByVal _cpu_value As String)
                _cpu = _cpu_value
            End Set
        End Property

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property osfamily_id() As Integer
            Get
                Return _osfamily_id
            End Get
            Set(ByVal _osfamily_id_value As Integer)
                _osfamily_id = _osfamily_id_value
            End Set
        End Property

        Public Property oslicence_id() As Integer
            Get
                Return _oslicence_id
            End Get
            Set(ByVal _oslicence_id_value As Integer)
                _oslicence_id = _oslicence_id_value
            End Set
        End Property

        Public Property osversion_id() As Integer
            Get
                Return _osversion_id
            End Get
            Set(ByVal _osversion_id_value As Integer)
                _osversion_id = _osversion_id_value
            End Set
        End Property

        Public Property ram() As String
            Get
                Return _ram
            End Get
            Set(ByVal _ram_value As String)
                _ram = _ram_value
            End Set
        End Property

    End Class

    Public Class NetworkDeviceQT : Inherits NetworkDevice
        '
    End Class

    Public Class NetworkDevice : Inherits DataCenterDevice
        Private _code_isoversion As Integer
        Private _code_networkdevicetype As Integer
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _ram As String

        Public Property code_isoversion() As Integer
            Get
                Return _code_isoversion
            End Get
            Set(ByVal _code_isoversion_value As Integer)
                _code_isoversion = _code_isoversion_value
            End Set
        End Property

        Public Property code_networkdevicetype() As Integer
            Get
                Return _code_networkdevicetype
            End Get
            Set(ByVal _code_networkdevicetype_value As Integer)
                _code_networkdevicetype = _code_networkdevicetype_value
            End Set
        End Property

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property ram() As String
            Get
                Return _ram
            End Get
            Set(ByVal _ram_value As String)
                _ram = _ram_value
            End Set
        End Property

    End Class

    ' ------------------------------
    ' VirtualDevice * 
    Public Class VirtualHost : Inherits VirtualDevice
        Private _id As Integer
        Private __IsDeleted As Boolean

        Public Shadows Const TABLE_NAME As String = "VirtualHost"

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

    End Class


    Public Class VirtualMachineQT : Inherits VirtualMachine
        ' Nothing
        Public Shadows Const TABLE_NAME As String = "VirtualMachineQT"
    End Class


    Public Class VirtualMachine : Inherits VirtualDevice
        Private _id As Integer
        Private _virtualhost_identify As Integer
        Private _osfamily_identify As Integer
        Private _oslicence_identify As Integer
        Private _osversion_identify As Integer
        Private _managementip_identify As Integer
        Private _code_backup_plan As Integer
        Private _cpu As String
        Private _ram As String
        Private __IsDeleted As Boolean

        Public Shadows Const TABLE_NAME As String = "VirtualMachine"

        Public Const C_VIRTUALHOST_IDENTIFY As String = "virtualhost_identify"
        Public Const C_OSFAMILY_IDENTIFY As String = "osfamily_identify"
        Public Const C_OSLICENCE_IDENTIFY As String = "oslicence_identify"
        Public Const C_OSVERSION_IDENTIFY As String = "osversion_identify"
        Public Const C_MANAGEMENTIP_IDENTIFY As String = "managementip_identify"
        Public Const C_CODE_BACKUP_PLAN As String = "code_backup_plan"
        Public Const C_CPU As String = "cpu"
        Public Const C_RAM As String = "ram"

        Public Property code_backup_plan() As Integer
            Get
                Return _code_backup_plan
            End Get
            Set(ByVal _code_backup_plan_value As Integer)
                _code_backup_plan = _code_backup_plan_value
            End Set
        End Property

        Public Property cpu() As String
            Get
                Return _cpu
            End Get
            Set(ByVal _cpu_value As String)
                _cpu = _cpu_value
            End Set
        End Property

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property managementip_identify() As Integer
            Get
                Return _managementip_identify
            End Get
            Set(ByVal _managementip_identify_value As Integer)
                _managementip_identify = _managementip_identify_value
            End Set
        End Property

        Public Property osfamily_identify() As Integer
            Get
                Return _osfamily_identify
            End Get
            Set(ByVal _osfamily_identify_value As Integer)
                _osfamily_identify = _osfamily_identify_value
            End Set
        End Property

        Public Property oslicence_identify() As Integer
            Get
                Return _oslicence_identify
            End Get
            Set(ByVal _oslicence_identify_value As Integer)
                _oslicence_identify = _oslicence_identify_value
            End Set
        End Property

        Public Property osversion_identify() As Integer
            Get
                Return _osversion_identify
            End Get
            Set(ByVal _osversion_identify_value As Integer)
                _osversion_identify = _osversion_identify_value
            End Set
        End Property

        Public Property ram() As String
            Get
                Return _ram
            End Get
            Set(ByVal _ram_value As String)
                _ram = _ram_value
            End Set
        End Property

        Public Property virtualhost_identify() As Integer
            Get
                Return _virtualhost_identify
            End Get
            Set(ByVal _virtualhost_identify_value As Integer)
                _virtualhost_identify = _virtualhost_identify_value
            End Set
        End Property

    End Class

    Public Class FarmQT : Inherits Farm
        '
    End Class

    Public Class Farm : Inherits VirtualHost
        Private _id As Integer
        Private _code_deployment_area As Integer
        Private _code_farm_status As Integer
        Private _code_farm_type As Integer
        Private _redundancy As Boolean
        Private __IsDeleted As Boolean

        Public Shadows Const TABLE_NAME As String = "Farm"

        Public Const C_CODE_DEPLOYMENT_AREA As String = "code_deployment_area"
        Public Const C_CODE_FARM_STATUS As String = "code_farm_status"
        Public Const C_CODE_FARM_TYPE As String = "code_farm_type"
        Public Const C_REDUNDANCY As String = "redundancy"

        Public Property code_deployment_area() As Integer
            Get
                Return _code_deployment_area
            End Get
            Set(ByVal _code_deployment_area_value As Integer)
                _code_deployment_area = _code_deployment_area_value
            End Set
        End Property

        Public Property code_farm_status() As Integer
            Get
                Return _code_farm_status
            End Get
            Set(ByVal _code_farm_status_value As Integer)
                _code_farm_status = _code_farm_status_value
            End Set
        End Property

        Public Property code_farm_type() As Integer
            Get
                Return _code_farm_type
            End Get
            Set(ByVal _code_farm_type_value As Integer)
                _code_farm_type = _code_farm_type_value
            End Set
        End Property

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property redundancy() As Boolean
            Get
                Return _redundancy
            End Get
            Set(ByVal _redundancy_value As Boolean)
                _redundancy = _redundancy_value
            End Set
        End Property

    End Class

    Public Class HypervisorQT : Inherits Hypervisor
        '
    End Class

    Public Class Hypervisor : Inherits VirtualHost
        Private _farm_identify As Integer
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _server_identify As Integer

        Public Shadows Const TABLE_NAME As String = "Hypervisor"

        Public Const C_FARM_IDENTIFY As String = "farm_identify"
        Public Const C_SERVER_IDENTIFY As String = "server_identify"

        Public Property farm_identify() As Integer
            Get
                Return _farm_identify
            End Get
            Set(ByVal _farm_identify_value As Integer)
                _farm_identify = _farm_identify_value
            End Set
        End Property

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property server_identify() As Integer
            Get
                Return _server_identify
            End Get
            Set(ByVal _server_identify_value As Integer)
                _server_identify = _server_identify_value
            End Set
        End Property

    End Class


    ' ------------------------------
    ' SoftwareInstance * 
    Public Class DBServerQT : Inherits DBServer
        ' 
    End Class

    Public Class DBServer : Inherits SoftwareInstance
        Private _id As Integer
        Private __IsDeleted As Boolean


        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

    End Class

    Public Class MiddlewareQT : Inherits Middleware
        ' 
    End Class

    Public Class Middleware : Inherits SoftwareInstance
        Private _id As Integer
        Private __IsDeleted As Boolean

        Public Shadows Const TABLE_NAME As String = "Middleware"

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

    End Class

    Public Class WebServerQT : Inherits WebServer
        '
    End Class

    Public Class WebServer : Inherits SoftwareInstance
        Private _id As Integer
        Private __IsDeleted As Boolean

        Public Shadows Const TABLE_NAME As String = "WebServer"

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

    End Class

    ' ------------------------------
    ' IPObject * 
    Public Class IPObject

        Private _allocation_date As Date
        Private _code_ipobject_status As Integer
        Private _comment As String
        Private _finalclass As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _organization_identify As Integer
        Private _release_date As Date
        Private _requestor_identify As Integer

        Public Property allocation_date() As Date
            Get
                Return _allocation_date
            End Get
            Set(ByVal _allocation_date_value As Date)
                _allocation_date = _allocation_date_value
            End Set
        End Property

        Public Property code_ipobject_status() As Integer
            Get
                Return _code_ipobject_status
            End Get
            Set(ByVal _code_ipobject_status_value As Integer)
                _code_ipobject_status = _code_ipobject_status_value
            End Set
        End Property

        Public Property comment() As String
            Get
                Return _comment
            End Get
            Set(ByVal _comment_value As String)
                _comment = _comment_value
            End Set
        End Property

        Public Property finalclass() As String
            Get
                Return _finalclass
            End Get
            Set(ByVal _finalclass_value As String)
                _finalclass = _finalclass_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property organization_identify() As Integer
            Get
                Return _organization_identify
            End Get
            Set(ByVal _organization_identify_value As Integer)
                _organization_identify = _organization_identify_value
            End Set
        End Property

        Public Property release_date() As Date
            Get
                Return _release_date
            End Get
            Set(ByVal _release_date_value As Date)
                _release_date = _release_date_value
            End Set
        End Property

        Public Property requestor_identify() As Integer
            Get
                Return _requestor_identify
            End Get
            Set(ByVal _requestor_identify_value As Integer)
                _requestor_identify = _requestor_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class IPBlock : Inherits IPObject
        Private _children_occupancy As Integer
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _name As String
        Private _occupancy As Integer
        Private _parent_identify As Integer
        Private _subnet_occupancy As Integer
        Private _type As String
        Private _write_reason As String

        Public Shadows Const TABLE_NAME As String = "IPBlock"

        Public Const C__ISDELETED As String = "_IsDeleted"
        Public Const C_CHILDREN_OCCUPANCY As String = "children_occupancy"
        Public Const C_NAME As String = "name"
        Public Const C_OCCUPANCY As String = "occupancy"
        Public Const C_PARENT_IDENTIFY As String = "parent_identify"
        Public Const C_SUBNET_OCCUPANCY As String = "subnet_occupancy"
        Public Const C_TYPE As String = "type"
        Public Const C_WRITE_REASON As String = "write_reason"

        Public Property children_occupancy() As Integer
            Get
                Return _children_occupancy
            End Get
            Set(ByVal _children_occupancy_value As Integer)
                _children_occupancy = _children_occupancy_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property occupancy() As Integer
            Get
                Return _occupancy
            End Get
            Set(ByVal _occupancy_value As Integer)
                _occupancy = _occupancy_value
            End Set
        End Property

        Public Property parent_identify() As Integer
            Get
                Return _parent_identify
            End Get
            Set(ByVal _parent_identify_value As Integer)
                _parent_identify = _parent_identify_value
            End Set
        End Property

        Public Property subnet_occupancy() As Integer
            Get
                Return _subnet_occupancy
            End Get
            Set(ByVal _subnet_occupancy_value As Integer)
                _subnet_occupancy = _subnet_occupancy_value
            End Set
        End Property

        Public Property type() As String
            Get
                Return _type
            End Get
            Set(ByVal _type_value As String)
                _type = _type_value
            End Set
        End Property

        Public Property write_reason() As String
            Get
                Return _write_reason
            End Get
            Set(ByVal _write_reason_value As String)
                _write_reason = _write_reason_value
            End Set
        End Property

    End Class

    Public Class IPBlockv4QT : Inherits IPBlockv4
        ' 
    End Class

    Public Class IPBlockv4 : Inherits IPBlock
        Private _firstip As String
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _lastip As String
        Private _parent_identify As Integer
        Private _parent_identify_left As Integer
        Private _parent_identify_right As Integer

        Public Shadows Const TABLE_NAME As String = "IPBlockv4"

        Public Const C_FIRSTIP As String = "firstip"
        Public Const C_LASTIP As String = "lastip"
        Public Shadows Const C_PARENT_IDENTIFY As String = "parent_identify"
        Public Const C_PARENT_IDENTIFY_LEFT As String = "parent_identify_left"
        Public Const C_PARENT_IDENTIFY_RIGHT As String = "parent_identify_right"

        Public Property firstip() As String
            Get
                Return _firstip
            End Get
            Set(ByVal _firstip_value As String)
                _firstip = _firstip_value
            End Set
        End Property

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property lastip() As String
            Get
                Return _lastip
            End Get
            Set(ByVal _lastip_value As String)
                _lastip = _lastip_value
            End Set
        End Property

        Public Overloads Property parent_identify() As Integer
            Get
                Return _parent_identify
            End Get
            Set(ByVal _parent_identify_value As Integer)
                _parent_identify = _parent_identify_value
            End Set
        End Property

        Public Property parent_identify_left() As Integer
            Get
                Return _parent_identify_left
            End Get
            Set(ByVal _parent_identify_left_value As Integer)
                _parent_identify_left = _parent_identify_left_value
            End Set
        End Property

        Public Property parent_identify_right() As Integer
            Get
                Return _parent_identify_right
            End Get
            Set(ByVal _parent_identify_right_value As Integer)
                _parent_identify_right = _parent_identify_right_value
            End Set
        End Property

    End Class


    Public Class IPSubnet : Inherits IPObject
        Private _alarm_water_mark As String
        Private _id As Integer
        Private _ip_occupancy As Integer
        Private __IsDeleted As Boolean
        Private _name As String
        Private _range_occupancy As Integer
        Private _type As String
        Private _write_reason As String

        Public Shadows Const TABLE_NAME As String = "IPSubnet"

        Public Const C__ISDELETED As String = "_IsDeleted"
        Public Const C_ALARM_WATER_MARK As String = "alarm_water_mark"
        Public Const C_ID As String = "id"
        Public Const C_IP_OCCUPANCY As String = "ip_occupancy"
        Public Const C_NAME As String = "name"
        Public Const C_RANGE_OCCUPANCY As String = "range_occupancy"
        Public Const C_TYPE As String = "type"
        Public Const C_WRITE_REASON As String = "write_reason"

        Public Property alarm_water_mark() As String
            Get
                Return _alarm_water_mark
            End Get
            Set(ByVal _alarm_water_mark_value As String)
                _alarm_water_mark = _alarm_water_mark_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Property ip_occupancy() As Integer
            Get
                Return _ip_occupancy
            End Get
            Set(ByVal _ip_occupancy_value As Integer)
                _ip_occupancy = _ip_occupancy_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property range_occupancy() As Integer
            Get
                Return _range_occupancy
            End Get
            Set(ByVal _range_occupancy_value As Integer)
                _range_occupancy = _range_occupancy_value
            End Set
        End Property

        Public Property type() As String
            Get
                Return _type
            End Get
            Set(ByVal _type_value As String)
                _type = _type_value
            End Set
        End Property

        Public Property write_reason() As String
            Get
                Return _write_reason
            End Get
            Set(ByVal _write_reason_value As String)
                _write_reason = _write_reason_value
            End Set
        End Property

    End Class

    Public Class IPSubnetv4QT : Inherits IPSubnetv4
        ' 
    End Class

    Public Class IPSubnetv4 : Inherits IPSubnet
        Private __use As String
        Private _code As String
        Private _code_deployment_area As Integer
        Private _description As String
        Private _geteway As String
        Private _id As Integer
        Private _ip_end As String
        Private _ip_start As String
        Private _ipv4block_identify As Integer
        Private __IsDeleted As Boolean
        Private _netmask As String
        Private _network_no As String
        Private _region As String

        Public Shadows Const TABLE_NAME As String = "IPSubnetv4"

        Public Const C__USE As String = "_use"
        Public Const C_CODE As String = "code"
        Public Const C_CODE_DEPLOYMENT_AREA As String = "code_deployment_area"
        Public Const C_DESCRIPTION As String = "description"
        Public Const C_GETEWAY As String = "geteway"
        Public Const C_IP_END As String = "ip_end"
        Public Const C_IP_START As String = "ip_start"
        Public Const C_IPV4BLOCK_IDENTIFY As String = "ipv4block_identify"
        Public Const C_NETMASK As String = "netmask"
        Public Const C_NETWORK_NO As String = "network_no"
        Public Shadows Const C_ORGANIZATION_IDENTIFY As String = "organization_identify"
        Public Const C_REGION As String = "region"

        Public Property _use() As String
            Get
                Return __use
            End Get
            Set(ByVal __use_value As String)
                __use = __use_value
            End Set
        End Property

        Public Property code() As String
            Get
                Return _code
            End Get
            Set(ByVal _code_value As String)
                _code = _code_value
            End Set
        End Property

        Public Property code_deployment_area() As Integer
            Get
                Return _code_deployment_area
            End Get
            Set(ByVal _code_deployment_area_value As Integer)
                _code_deployment_area = _code_deployment_area_value
            End Set
        End Property

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property geteway() As String
            Get
                Return _geteway
            End Get
            Set(ByVal _geteway_value As String)
                _geteway = _geteway_value
            End Set
        End Property

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Property ip_end() As String
            Get
                Return _ip_end
            End Get
            Set(ByVal _ip_end_value As String)
                _ip_end = _ip_end_value
            End Set
        End Property

        Public Property ip_start() As String
            Get
                Return _ip_start
            End Get
            Set(ByVal _ip_start_value As String)
                _ip_start = _ip_start_value
            End Set
        End Property

        Public Property ipv4block_identify() As Integer
            Get
                Return _ipv4block_identify
            End Get
            Set(ByVal _ipv4block_identify_value As Integer)
                _ipv4block_identify = _ipv4block_identify_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property netmask() As String
            Get
                Return _netmask
            End Get
            Set(ByVal _netmask_value As String)
                _netmask = _netmask_value
            End Set
        End Property

        Public Property network_no() As String
            Get
                Return _network_no
            End Get
            Set(ByVal _network_no_value As String)
                _network_no = _network_no_value
            End Set
        End Property

        Public Property region() As String
            Get
                Return _region
            End Get
            Set(ByVal _region_value As String)
                _region = _region_value
            End Set
        End Property

    End Class


    Public Class IPAddress : Inherits IPObject
        Private _code_ipaddress_usage As Integer
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _short_name As String

        Public Shadows Const TABLE_NAME As String = "IPAddress"

        Public Const C_CODE_IPADDRESS_USAGE As String = "code_ipaddress_usage"
        Public Const C_SHORT_NAME As String = "short_name"

        Public Property code_ipaddress_usage() As Integer
            Get
                Return _code_ipaddress_usage
            End Get
            Set(ByVal _code_ipaddress_usage_value As Integer)
                _code_ipaddress_usage = _code_ipaddress_usage_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property short_name() As String
            Get
                Return _short_name
            End Get
            Set(ByVal _short_name_value As String)
                _short_name = _short_name_value
            End Set
        End Property

    End Class

    Public Class IPAddressv4QT : Inherits IPAddressv4
        ' 
    End Class

    Public Class IPAddressv4 : Inherits IPAddress
        Private _code_ipv4address_usage As Integer
        Private _description As String
        Private _id As Integer
        Private _ip As String
        Private __IsDeleted As Boolean
        Private _vlan_identify As Integer

        Public Shadows Const TABLE_NAME As String = "IPAddressv4"

        Public Const C_CODE_IPV4ADDRESS_USAGE As String = "code_ipv4address_usage"
        Public Const C_DESCRIPTION As String = "description"
        Public Const C_IP As String = "ip"
        Public Const C_VLAN_IDENTIFY As String = "vlan_identify"

        Public Property code_ipv4address_usage() As Integer
            Get
                Return _code_ipv4address_usage
            End Get
            Set(ByVal _code_ipv4address_usage_value As Integer)
                _code_ipv4address_usage = _code_ipv4address_usage_value
            End Set
        End Property

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Property ip() As String
            Get
                Return _ip
            End Get
            Set(ByVal _ip_value As String)
                _ip = _ip_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property vlan_identify() As Integer
            Get
                Return _vlan_identify
            End Get
            Set(ByVal _vlan_identify_value As Integer)
                _vlan_identify = _vlan_identify_value
            End Set
        End Property

    End Class

    ' ------------------------------
    ' Typology * 
    Public Class Typology

        Private _finalclass As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _name As String

        Public Const TABLE_NAME As String = "Typology"

        Public Const C_FINALCLASS As String = "finalclass"
        Public Const C_NAME As String = "name"

        Public Property finalclass() As String
            Get
                Return _finalclass
            End Get
            Set(ByVal _finalclass_value As String)
                _finalclass = _finalclass_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class

    Public Class OSFamilyQT : Inherits OSFamily
        ' 
    End Class

    Public Class OSFamily : Inherits Typology
        Private _id As Integer
        Private __IsDeleted As Boolean

        Public Shadows Const TABLE_NAME As String = "OSFamily"

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

    End Class

    Public Class OSVersionQT : Inherits OSVersion
        ' 
    End Class

    Public Class OSVersion : Inherits Typology
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _osfamily_id As Integer

        Public Shadows Const TABLE_NAME As String = "OSVersion"

        Public Const C_OSFAMILY_ID As String = "osfamily_id"

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property osfamily_id() As Integer
            Get
                Return _osfamily_id
            End Get
            Set(ByVal _osfamily_id_value As Integer)
                _osfamily_id = _osfamily_id_value
            End Set
        End Property

    End Class

    ' ------------------------------
    ' NetworkInterface* 
    Public Class NetworkInterface

        Private _finalclass As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _name As String
        Private _obsolescence_date As Date

        Public Const TABLE_NAME As String = "NetworkInterface"

        Public Const C__IDENTIFY As String = "__Identify"
        Public Const C__ISDELETED As String = "_IsDeleted"
        Public Const C_FINALCLASS As String = "finalclass"
        Public Const C_NAME As String = "name"
        Public Const C_OBSOLESCENCE_DATE As String = "obsolescence_date"

        Public Property finalclass() As String
            Get
                Return _finalclass
            End Get
            Set(ByVal _finalclass_value As String)
                _finalclass = _finalclass_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property obsolescence_date() As Date
            Get
                Return _obsolescence_date
            End Get
            Set(ByVal _obsolescence_date_value As Date)
                _obsolescence_date = _obsolescence_date_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class

    Public Class FiberChannelInterfaceQT : Inherits FiberChannelInterface
        ' 
    End Class

    Public Class FiberChannelInterface : Inherits NetworkInterface
        Private _datacenterdevice_identify As Integer
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _speed As Decimal
        Private _topology As String
        Private _wwn As String

        Public Shadows Const TABLE_NAME As String = "FiberChannelInterface"

        Public Const C_DATACENTERDEVICE_IDENTIFY As String = "datacenterdevice_identify"
        Public Const C_ID As String = "id"
        Public Const C_SPEED As String = "speed"
        Public Const C_TOPOLOGY As String = "topology"
        Public Const C_WWN As String = "wwn"

        Public Property datacenterdevice_identify() As Integer
            Get
                Return _datacenterdevice_identify
            End Get
            Set(ByVal _datacenterdevice_identify_value As Integer)
                _datacenterdevice_identify = _datacenterdevice_identify_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property speed() As Decimal
            Get
                Return _speed
            End Get
            Set(ByVal _speed_value As Decimal)
                _speed = _speed_value
            End Set
        End Property

        Public Property topology() As String
            Get
                Return _topology
            End Get
            Set(ByVal _topology_value As String)
                _topology = _topology_value
            End Set
        End Property

        Public Property wwn() As String
            Get
                Return _wwn
            End Get
            Set(ByVal _wwn_value As String)
                _wwn = _wwn_value
            End Set
        End Property

    End Class


    Public Class IPInterface : Inherits NetworkInterface
        Private _comment As String
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _macaddress As String
        Private _speed As Decimal

        Public Shadows Const TABLE_NAME As String = "IPInterface"

        Public Const C_COMMENT As String = "comment"
        Public Const C_MACADDRESS As String = "macaddress"
        Public Const C_SPEED As String = "speed"

        Public Property comment() As String
            Get
                Return _comment
            End Get
            Set(ByVal _comment_value As String)
                _comment = _comment_value
            End Set
        End Property

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property macaddress() As String
            Get
                Return _macaddress
            End Get
            Set(ByVal _macaddress_value As String)
                _macaddress = _macaddress_value
            End Set
        End Property

        Public Property speed() As Decimal
            Get
                Return _speed
            End Get
            Set(ByVal _speed_value As Decimal)
                _speed = _speed_value
            End Set
        End Property

    End Class

    Public Class LogicalInterfaceQT : Inherits LogicalInterface
        ' 
    End Class

    Public Class LogicalInterface : Inherits IPInterface
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _virtualmachine_identify As Integer

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property virtualmachine_identify() As Integer
            Get
                Return _virtualmachine_identify
            End Get
            Set(ByVal _virtualmachine_identify_value As Integer)
                _virtualmachine_identify = _virtualmachine_identify_value
            End Set
        End Property

    End Class

    Public Class PhysicalInterfaceQT : Inherits PhysicalInterface
        ' 
    End Class

    Public Class PhysicalInterface : Inherits IPInterface
        Private _connectableci_identify As Integer
        Private _id As Integer
        Private __IsDeleted As Boolean

        Public Shadows Const TABLE_NAME As String = "PhysicalInterface"

        Public Const C_CONNECTABLECI_IDENTIFY As String = "connectableci_identify"

        Public Property connectableci_identify() As Integer
            Get
                Return _connectableci_identify
            End Get
            Set(ByVal _connectableci_identify_value As Integer)
                _connectableci_identify = _connectableci_identify_value
            End Set
        End Property

        Public Overloads Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

    End Class

    ' ------------------------------
    ' Licence * 
    Public Class Licence

        Private _description As String
        Private _end_date As Date
        Private _finalclass As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _licence_key As String
        Private _name As String
        Private _obsolescence_date As Date
        Private _organization_identify As Integer
        Private _perpetual As Boolean
        Private _start_date As Date
        Private _usage_limit As String

        Public Const TABLE_NAME As String = "Licence"

        Public Const C_DESCRIPTION As String = "description"
        Public Const C_END_DATE As String = "end_date"
        Public Const C_FINALCLASS As String = "finalclass"
        Public Const C_LICENCE_KEY As String = "licence_key"
        Public Const C_NAME As String = "name"
        Public Const C_OBSOLESCENCE_DATE As String = "obsolescence_date"
        Public Const C_ORGANIZATION_IDENTIFY As String = "organization_identify"
        Public Const C_PERPETUAL As String = "perpetual"
        Public Const C_START_DATE As String = "start_date"
        Public Const C_USAGE_LIMIT As String = "usage_limit"

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property end_date() As Date
            Get
                Return _end_date
            End Get
            Set(ByVal _end_date_value As Date)
                _end_date = _end_date_value
            End Set
        End Property

        Public Property finalclass() As String
            Get
                Return _finalclass
            End Get
            Set(ByVal _finalclass_value As String)
                _finalclass = _finalclass_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property licence_key() As String
            Get
                Return _licence_key
            End Get
            Set(ByVal _licence_key_value As String)
                _licence_key = _licence_key_value
            End Set
        End Property

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal _name_value As String)
                _name = _name_value
            End Set
        End Property

        Public Property obsolescence_date() As Date
            Get
                Return _obsolescence_date
            End Get
            Set(ByVal _obsolescence_date_value As Date)
                _obsolescence_date = _obsolescence_date_value
            End Set
        End Property

        Public Property organization_identify() As Integer
            Get
                Return _organization_identify
            End Get
            Set(ByVal _organization_identify_value As Integer)
                _organization_identify = _organization_identify_value
            End Set
        End Property

        Public Property perpetual() As Boolean
            Get
                Return _perpetual
            End Get
            Set(ByVal _perpetual_value As Boolean)
                _perpetual = _perpetual_value
            End Set
        End Property

        Public Property start_date() As Date
            Get
                Return _start_date
            End Get
            Set(ByVal _start_date_value As Date)
                _start_date = _start_date_value
            End Set
        End Property

        Public Property usage_limit() As String
            Get
                Return _usage_limit
            End Get
            Set(ByVal _usage_limit_value As String)
                _usage_limit = _usage_limit_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class OSLicence : Inherits Licence
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _osversion_identify As Integer

        Public Shadows Const TABLE_NAME As String = "OSLicence"

        Public Const C_ID As String = "id"
        Public Const C_OSVERSION_IDENTIFY As String = "osversion_identify"

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property osversion_identify() As Integer
            Get
                Return _osversion_identify
            End Get
            Set(ByVal _osversion_identify_value As Integer)
                _osversion_identify = _osversion_identify_value
            End Set
        End Property
    End Class


    Public Class SoftwareLicence : Inherits Licence
        Private _id As Integer
        Private __IsDeleted As Boolean
        Private _software_identify As Integer

        Public Shadows Const TABLE_NAME As String = "SoftwareLicence"

        Public Const C_SOFTWARE_IDENTIFY As String = "software_identify"

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal _id_value As Integer)
                _id = _id_value
            End Set
        End Property

        Public Overloads Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property software_identify() As Integer
            Get
                Return _software_identify
            End Get
            Set(ByVal _software_identify_value As Integer)
                _software_identify = _software_identify_value
            End Set
        End Property

    End Class


    ' ------------------------------
    ' Lnk *
    Public Class LnkApplicationSolutionToFunctionalCI

        Private _applicationsolution_identify As Integer
        Private _functionalci_identify As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean

        Public Const C_APPLICATIONSOLUTION_IDENTIFY As String = "applicationsolution_identify"
        Public Const C_FUNCTIONALCI_IDENTIFY As String = "functionalci_identify"

        Public Property applicationsolution_identify() As Integer
            Get
                Return _applicationsolution_identify
            End Get
            Set(ByVal _applicationsolution_identify_value As Integer)
                _applicationsolution_identify = _applicationsolution_identify_value
            End Set
        End Property

        Public Property functionalci_identify() As Integer
            Get
                Return _functionalci_identify
            End Get
            Set(ByVal _functionalci_identify_value As Integer)
                _functionalci_identify = _functionalci_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkBackupsToFunctionalCI

        Private _backups_identify As Integer
        Private _functionalci_identify As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean

        Public Const TABLE_NAME As String = "LnkBackupsToFunctionalCI"

        Public Const C_BACKUPS_IDENTIFY As String = "backups_identify"
        Public Const C_FUNCTIONALCI_IDENTIFY As String = "functionalci_identify"

        Public Property backups_identify() As Integer
            Get
                Return _backups_identify
            End Get
            Set(ByVal _backups_identify_value As Integer)
                _backups_identify = _backups_identify_value
            End Set
        End Property

        Public Property functionalci_identify() As Integer
            Get
                Return _functionalci_identify
            End Get
            Set(ByVal _functionalci_identify_value As Integer)
                _functionalci_identify = _functionalci_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkCIGroupToCI

        Private _ci_identify As Integer
        Private _cigroup_identify As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _reason As String

        Public Const TABLE_NAME As String = "LnkCIGroupToCI"

        Public Const C_CI_IDENTIFY As String = "ci_identify"
        Public Const C_CIGROUP_IDENTIFY As String = "cigroup_identify"
        Public Const C_REASON As String = "reason"

        Public Property ci_identify() As Integer
            Get
                Return _ci_identify
            End Get
            Set(ByVal _ci_identify_value As Integer)
                _ci_identify = _ci_identify_value
            End Set
        End Property

        Public Property cigroup_identify() As Integer
            Get
                Return _cigroup_identify
            End Get
            Set(ByVal _cigroup_identify_value As Integer)
                _cigroup_identify = _cigroup_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property reason() As String
            Get
                Return _reason
            End Get
            Set(ByVal _reason_value As String)
                _reason = _reason_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkConnectableCIToNetworkDevice

        Private _code_connectable_type As Integer
        Private _connectableci_identify As Integer
        Private _device_port As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _network_port As Integer
        Private _networkdevice_identify As Integer

        Public Const TABLE_NAME As String = "LnkConnectableCIToNetworkDevice"

        Public Const C_CODE_CONNECTABLE_TYPE As String = "code_connectable_type"
        Public Const C_CONNECTABLECI_IDENTIFY As String = "connectableci_identify"
        Public Const C_DEVICE_PORT As String = "device_port"
        Public Const C_NETWORK_PORT As String = "network_port"
        Public Const C_NETWORKDEVICE_IDENTIFY As String = "networkdevice_identify"

        Public Property code_connectable_type() As Integer
            Get
                Return _code_connectable_type
            End Get
            Set(ByVal _code_connectable_type_value As Integer)
                _code_connectable_type = _code_connectable_type_value
            End Set
        End Property

        Public Property connectableci_identify() As Integer
            Get
                Return _connectableci_identify
            End Get
            Set(ByVal _connectableci_identify_value As Integer)
                _connectableci_identify = _connectableci_identify_value
            End Set
        End Property

        Public Property device_port() As Integer
            Get
                Return _device_port
            End Get
            Set(ByVal _device_port_value As Integer)
                _device_port = _device_port_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property network_port() As Integer
            Get
                Return _network_port
            End Get
            Set(ByVal _network_port_value As Integer)
                _network_port = _network_port_value
            End Set
        End Property

        Public Property networkdevice_identify() As Integer
            Get
                Return _networkdevice_identify
            End Get
            Set(ByVal _networkdevice_identify_value As Integer)
                _networkdevice_identify = _networkdevice_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkContactToContract

        Private _contact_identify As Integer
        Private _contract_identify As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean

        Public Const TABLE_NAME As String = "LnkContactToContract"

        Public Const C_CONTACT_IDENTIFY As String = "contact_identify"
        Public Const C_CONTRACT_IDENTIFY As String = "contract_identify"

        Public Property contact_identify() As Integer
            Get
                Return _contact_identify
            End Get
            Set(ByVal _contact_identify_value As Integer)
                _contact_identify = _contact_identify_value
            End Set
        End Property

        Public Property contract_identify() As Integer
            Get
                Return _contract_identify
            End Get
            Set(ByVal _contract_identify_value As Integer)
                _contract_identify = _contract_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkContactToFunctionalCI

        Private _contact_identify As Integer
        Private _functionalci_identify As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean

        Public Const TABLE_NAME As String = "LnkContactToFunctionalCI"

        Public Const C_CONTACT_IDENTIFY As String = "contact_identify"
        Public Const C_FUNCTIONALCI_IDENTIFY As String = "functionalci_identify"

        Public Property contact_identify() As Integer
            Get
                Return _contact_identify
            End Get
            Set(ByVal _contact_identify_value As Integer)
                _contact_identify = _contact_identify_value
            End Set
        End Property

        Public Property functionalci_identify() As Integer
            Get
                Return _functionalci_identify
            End Get
            Set(ByVal _functionalci_identify_value As Integer)
                _functionalci_identify = _functionalci_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkContactToIPObject

        Private _contact_identify As Integer
        Private __Identify As Integer
        Private _ipobject_identify As Integer
        Private __IsDeleted As Boolean

        Public Const TABLE_NAME As String = "LnkContactToIPObject"

        Public Const C_CONTACT_IDENTIFY As String = "contact_identify"
        Public Const C_IPOBJECT_IDENTIFY As String = "ipobject_identify"

        Public Property contact_identify() As Integer
            Get
                Return _contact_identify
            End Get
            Set(ByVal _contact_identify_value As Integer)
                _contact_identify = _contact_identify_value
            End Set
        End Property

        Public Property ipobject_identify() As Integer
            Get
                Return _ipobject_identify
            End Get
            Set(ByVal _ipobject_identify_value As Integer)
                _ipobject_identify = _ipobject_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkContractToDocument

        Private _contract_identify As Integer
        Private _document_identify As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean

        Public Const TABLE_NAME As String = "LnkContractToDocument"

        Public Const C_CONTRACT_IDENTIFY As String = "contract_identify"
        Public Const C_DOCUMENT_IDENTIFY As String = "document_identify"

        Public Property contract_identify() As Integer
            Get
                Return _contract_identify
            End Get
            Set(ByVal _contract_identify_value As Integer)
                _contract_identify = _contract_identify_value
            End Set
        End Property

        Public Property document_identify() As Integer
            Get
                Return _document_identify
            End Get
            Set(ByVal _document_identify_value As Integer)
                _document_identify = _document_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkCustomerContractToProviderContract

        Private _customercontract_identify As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _providercontract_identify As Integer

        Public Const TABLE_NAME As String = "LnkCustomerContractToProviderContract"

        Public Const C_CUSTOMERCONTRACT_IDENTIFY As String = "customercontract_identify"
        Public Const C_PROVIDERCONTRACT_IDENTIFY As String = "providercontract_identify"

        Public Property customercontract_identify() As Integer
            Get
                Return _customercontract_identify
            End Get
            Set(ByVal _customercontract_identify_value As Integer)
                _customercontract_identify = _customercontract_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property providercontract_identify() As Integer
            Get
                Return _providercontract_identify
            End Get
            Set(ByVal _providercontract_identify_value As Integer)
                _providercontract_identify = _providercontract_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkDatacenterDeviceToSan

        Private _datacenterdevice_id As Integer
        Private _datacenterdevice_port As String
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _san_identify As Integer
        Private _san_port As String

        Public Const TABLE_NAME As String = "LnkDatacenterDeviceToSan"

        Public Const C_DATACENTERDEVICE_ID As String = "datacenterdevice_id"
        Public Const C_DATACENTERDEVICE_PORT As String = "datacenterdevice_port"
        Public Const C_SAN_IDENTIFY As String = "san_identify"
        Public Const C_SAN_PORT As String = "san_port"

        Public Property datacenterdevice_id() As Integer
            Get
                Return _datacenterdevice_id
            End Get
            Set(ByVal _datacenterdevice_id_value As Integer)
                _datacenterdevice_id = _datacenterdevice_id_value
            End Set
        End Property

        Public Property datacenterdevice_port() As String
            Get
                Return _datacenterdevice_port
            End Get
            Set(ByVal _datacenterdevice_port_value As String)
                _datacenterdevice_port = _datacenterdevice_port_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property san_identify() As Integer
            Get
                Return _san_identify
            End Get
            Set(ByVal _san_identify_value As Integer)
                _san_identify = _san_identify_value
            End Set
        End Property

        Public Property san_port() As String
            Get
                Return _san_port
            End Get
            Set(ByVal _san_port_value As String)
                _san_port = _san_port_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkDocumentToFunctionalCI

        Private _document_identify As Integer
        Private _functionalci_identify As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean

        Public Const TABLE_NAME As String = "LnkDocumentToFunctionalCI"

        Public Const C_DOCUMENT_IDENTIFY As String = "document_identify"
        Public Const C_FUNCTIONALCI_IDENTIFY As String = "functionalci_identify"

        Public Property document_identify() As Integer
            Get
                Return _document_identify
            End Get
            Set(ByVal _document_identify_value As Integer)
                _document_identify = _document_identify_value
            End Set
        End Property

        Public Property functionalci_identify() As Integer
            Get
                Return _functionalci_identify
            End Get
            Set(ByVal _functionalci_identify_value As Integer)
                _functionalci_identify = _functionalci_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class

    ' ----------------------------------

    Public Class LnkDocumentToIPObject

        Private _document_identify As Integer
        Private __Identify As Integer
        Private _ipobject_identify As Integer
        Private __IsDeleted As Boolean

        Public Const TABLE_NAME As String = "LnkDocumentToIPObject"

        Public Const C_DOCUMENT_IDENTIFY As String = "document_identify"
        Public Const C_IPOBJECT_IDENTIFY As String = "ipobject_identify"

        Public Property document_identify() As Integer
            Get
                Return _document_identify
            End Get
            Set(ByVal _document_identify_value As Integer)
                _document_identify = _document_identify_value
            End Set
        End Property

        Public Property ipobject_identify() As Integer
            Get
                Return _ipobject_identify
            End Get
            Set(ByVal _ipobject_identify_value As Integer)
                _ipobject_identify = _ipobject_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkDocumentToLicence

        Private _document_identify As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _licence_identify As Integer

        Public Const TABLE_NAME As String = "LnkDocumentToLicence"

        Public Const C_DOCUMENT_IDENTIFY As String = "document_identify"
        Public Const C_LICENCE_IDENTIFY As String = "licence_identify"

        Public Property Document_identify() As Integer
            Get
                Return _document_identify
            End Get
            Set(ByVal _document_identify_value As Integer)
                _document_identify = _document_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property Licence_identify() As Integer
            Get
                Return _licence_identify
            End Get
            Set(ByVal _licence_identify_value As Integer)
                _licence_identify = _licence_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkDocumentToSoftware

        Private _document_identify As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _software_identify As Integer

        Public Const TABLE_NAME As String = "LnkDocumentToSoftware"

        Public Const C_DOCUMENT_IDENTIFY As String = "document_identify"
        Public Const C_SOFTWARE_IDENTIFY As String = "software_identify"

        Public Property document_identify() As Integer
            Get
                Return _document_identify
            End Get
            Set(ByVal _document_identify_value As Integer)
                _document_identify = _document_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property Software_identify() As Integer
            Get
                Return _software_identify
            End Get
            Set(ByVal _software_identify_value As Integer)
                _software_identify = _software_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkFunctionalCIToOrganization

        Private _description As String
        Private _functionalci_identify As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _organization_identify As Integer

        Public Const TABLE_NAME As String = "LnkFunctionalCIToOrganization"

        Public Const C__IDENTIFY As String = "__Identify"
        Public Const C__ISDELETED As String = "_IsDeleted"
        Public Const C_DESCRIPTION As String = "description"
        Public Const C_FUNCTIONALCI_IDENTIFY As String = "functionalci_identify"
        Public Const C_ORGANIZATION_IDENTIFY As String = "organization_identify"

        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal _description_value As String)
                _description = _description_value
            End Set
        End Property

        Public Property functionalci_identify() As Integer
            Get
                Return _functionalci_identify
            End Get
            Set(ByVal _functionalci_identify_value As Integer)
                _functionalci_identify = _functionalci_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property organization_identify() As Integer
            Get
                Return _organization_identify
            End Get
            Set(ByVal _organization_identify_value As Integer)
                _organization_identify = _organization_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkFunctionalCIToProviderContract

        Private _functionalci_identify As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _providercontract_identify As Integer

        Public Const TABLE_NAME As String = "LnkFunctionalCIToProviderContract"

        Public Const C_FUNCTIONALCI_IDENTIFY As String = "functionalci_identify"
        Public Const C_PROVIDERCONTRACT_IDENTIFY As String = "providercontract_identify"

        Public Property functionalci_identify() As Integer
            Get
                Return _functionalci_identify
            End Get
            Set(ByVal _functionalci_identify_value As Integer)
                _functionalci_identify = _functionalci_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property Providercontract_identify() As Integer
            Get
                Return _providercontract_identify
            End Get
            Set(ByVal _providercontract_identify_value As Integer)
                _providercontract_identify = _providercontract_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkIPAddressToIPAddress

        Private __Identify As Integer
        Private _ip1_identify As Integer
        Private _ip2_identify As Integer
        Private __IsDeleted As Boolean

        Public Const TABLE_NAME As String = "LnkIPAddressToIPAddress"

        Public Const C_IP1_IDENTIFY As String = "ip1_identify"
        Public Const C_IP2_IDENTIFY As String = "ip2_identify"

        Public Property Ip1_identify() As Integer
            Get
                Return _ip1_identify
            End Get
            Set(ByVal _ip1_identify_value As Integer)
                _ip1_identify = _ip1_identify_value
            End Set
        End Property

        Public Property ip2_identify() As Integer
            Get
                Return _ip2_identify
            End Get
            Set(ByVal _ip2_identify_value As Integer)
                _ip2_identify = _ip2_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkIPInterfaceToIPAddress

        Private __Identify As Integer
        Private _ipaddress_identify As Integer
        Private _ipinterface_identify As Integer
        Private __IsDeleted As Boolean

        Public Const TABLE_NAME As String = "LnkIPInterfaceToIPAddress"

        Public Const C_IPADDRESS_IDENTIFY As String = "ipaddress_identify"
        Public Const C_IPINTERFACE_IDENTIFY As String = "ipinterface_identify"

        Public Property ipaddress_identify() As Integer
            Get
                Return _ipaddress_identify
            End Get
            Set(ByVal _ipaddress_identify_value As Integer)
                _ipaddress_identify = _ipaddress_identify_value
            End Set
        End Property

        Public Property ipinterface_identify() As Integer
            Get
                Return _ipinterface_identify
            End Get
            Set(ByVal _ipinterface_identify_value As Integer)
                _ipinterface_identify = _ipinterface_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class

    ' ----------------------------------


    Public Class LnkIPSubnetToLocation

        Private __Identify As Integer
        Private _ipsubnet_identify As Integer
        Private __IsDeleted As Boolean
        Private _location_identify As Integer

        Public Const TABLE_NAME As String = "LnkIPSubnetToLocation"

        Public Const C_IPSUBNET_IDENTIFY As String = "ipsubnet_identify"
        Public Const C_LOCATION_IDENTIFY As String = "location_identify"

        Public Property ipsubnet_identify() As Integer
            Get
                Return _ipsubnet_identify
            End Get
            Set(ByVal _ipsubnet_identify_value As Integer)
                _ipsubnet_identify = _ipsubnet_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property location_identify() As Integer
            Get
                Return _location_identify
            End Get
            Set(ByVal _location_identify_value As Integer)
                _location_identify = _location_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkIPSubnetToVLAN

        Private __Identify As Integer
        Private _ipsubnet_identify As Integer
        Private __IsDeleted As Boolean
        Private _vlan_identify As Integer

        Public Const TABLE_NAME As String = "LnkIPSubnetToVLAN"

        Public Const C_IPSUBNET_IDENTIFY As String = "ipsubnet_identify"
        Public Const C_VLAN_IDENTIFY As String = "vlan_identify"

        Public Property ipsubnet_identify() As Integer
            Get
                Return _ipsubnet_identify
            End Get
            Set(ByVal _ipsubnet_identify_value As Integer)
                _ipsubnet_identify = _ipsubnet_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property vlan_identify() As Integer
            Get
                Return _vlan_identify
            End Get
            Set(ByVal _vlan_identify_value As Integer)
                _vlan_identify = _vlan_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkPasswdToFunctionalCI

        Private _functionalci_identify As Integer
        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _passwd_identify As Integer

        Public Const TABLE_NAME As String = "LnkPasswdToFunctionalCI"

        Public Const C_FUNCTIONALCI_IDENTIFY As String = "functionalci_identify"
        Public Const C_PASSWD_IDENTIFY As String = "passwd_identify"

        Public Property functionalci_identify() As Integer
            Get
                Return _functionalci_identify
            End Get
            Set(ByVal _functionalci_identify_value As Integer)
                _functionalci_identify = _functionalci_identify_value
            End Set
        End Property

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property passwd_identify() As Integer
            Get
                Return _passwd_identify
            End Get
            Set(ByVal _passwd_identify_value As Integer)
                _passwd_identify = _passwd_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkPhysicalInterfaceToVLAN

        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _physicalinterface_identify As Integer
        Private _vlan_identify As Integer

        Public Const TABLE_NAME As String = "LnkPhysicalInterfaceToVLAN"

        Public Const C_PHYSICALINTERFACE_IDENTIFY As String = "physicalinterface_identify"
        Public Const C_VLAN_IDENTIFY As String = "vlan_identify"

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property physicalinterface_identify() As Integer
            Get
                Return _physicalinterface_identify
            End Get
            Set(ByVal _physicalinterface_identify_value As Integer)
                _physicalinterface_identify = _physicalinterface_identify_value
            End Set
        End Property

        Public Property vlan_identify() As Integer
            Get
                Return _vlan_identify
            End Get
            Set(ByVal _vlan_identify_value As Integer)
                _vlan_identify = _vlan_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkServerToVolume

        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _server_identify As Integer
        Private _size_used As Integer
        Private _volume_identify As Integer

        Public Const TABLE_NAME As String = "LnkServerToVolume"

        Public Const C_SERVER_IDENTIFY As String = "server_identify"
        Public Const C_SIZE_USED As String = "size_used"
        Public Const C_VOLUME_IDENTIFY As String = "volume_identify"

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property Server_identify() As Integer
            Get
                Return _server_identify
            End Get
            Set(ByVal _server_identify_value As Integer)
                _server_identify = _server_identify_value
            End Set
        End Property

        Public Property Size_used() As Integer
            Get
                Return _size_used
            End Get
            Set(ByVal _size_used_value As Integer)
                _size_used = _size_used_value
            End Set
        End Property

        Public Property volume_identify() As Integer
            Get
                Return _volume_identify
            End Get
            Set(ByVal _volume_identify_value As Integer)
                _volume_identify = _volume_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkSubnetToVLAN

        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _subnet_identify As Integer
        Private _vlan_identify As Integer

        Public Const TABLE_NAME As String = "LnkSubnetToVLAN"

        Public Const C_SUBNET_IDENTIFY As String = "subnet_identify"
        Public Const C_VLAN_IDENTIFY As String = "vlan_identify"

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property subnet_identify() As Integer
            Get
                Return _subnet_identify
            End Get
            Set(ByVal _subnet_identify_value As Integer)
                _subnet_identify = _subnet_identify_value
            End Set
        End Property

        Public Property vlan_identify() As Integer
            Get
                Return _vlan_identify
            End Get
            Set(ByVal _vlan_identify_value As Integer)
                _vlan_identify = _vlan_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class


    Public Class LnkVirtualDeviceToVolume

        Private __Identify As Integer
        Private __IsDeleted As Boolean
        Private _size_used As Integer
        Private _virtualdevice_identify As Integer
        Private _volume_identify As Integer

        Public Const TABLE_NAME As String = "LnkVirtualDeviceToVolume"

        Public Const C_SIZE_USED As String = "size_used"
        Public Const C_VIRTUALDEVICE_IDENTIFY As String = "virtualdevice_identify"
        Public Const C_VOLUME_IDENTIFY As String = "volume_identify"

        Public Property _IsDeleted() As Boolean
            Get
                Return __IsDeleted
            End Get
            Set(ByVal _IsDeleted_value As Boolean)
                __IsDeleted = _IsDeleted_value
            End Set
        End Property

        Public Property size_used() As Integer
            Get
                Return _size_used
            End Get
            Set(ByVal _size_used_value As Integer)
                _size_used = _size_used_value
            End Set
        End Property

        Public Property virtualdevice_identify() As Integer
            Get
                Return _virtualdevice_identify
            End Get
            Set(ByVal _virtualdevice_identify_value As Integer)
                _virtualdevice_identify = _virtualdevice_identify_value
            End Set
        End Property

        Public Property Volume_identify() As Integer
            Get
                Return _volume_identify
            End Get
            Set(ByVal _volume_identify_value As Integer)
                _volume_identify = _volume_identify_value
            End Set
        End Property

        Public Property _Identify() As Integer
            Get
                Return __Identify
            End Get
            Set(ByVal __identify_value As Integer)
                __Identify = __identify_value
            End Set
        End Property

    End Class

End Namespace