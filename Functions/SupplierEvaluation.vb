Imports pbs.BO.DataAnnotations
Imports pbs.BO.Script
Imports pbs.BO
Imports pbs.Helper

Public Class SupplierEvaluation
    Implements IQueryBO
    Implements ISupportScripts
    Implements Interfaces.ISupportListEdit

    Private _effectiveDate As Helper.SmartDate = New Helper.SmartDate("T")
    Private _selectedDate As Helper.SmartDate = New Helper.SmartDate("T")
    'Private _supplierCode As String
    'Private _itemCode As String

#Region "IQueryBO"

    Public Sub AddQueryFilters(pDic As System.Collections.Generic.Dictionary(Of String, String)) Implements IQueryBO.AddQueryFilters

    End Sub

    Public ReadOnly Property ChildrenType As System.Type Implements IQueryBO.ChildrenType
        Get
            Return GetType(pbs.BO.PO.SEVInfo)
        End Get
    End Property

    Public Function GetBOList() As System.Collections.IList Implements IQueryBO.GetBOList
        Dim list = (From s In PO.SEVInfoList.GetSEVInfoList Where s._effectiveDate.ToString = _effectiveDate.ToString).ToList
        Return list
    End Function

    Public Function GetBOListStatus() As String Implements IQueryBO.GetBOListStatus
        Return "Supplier: {SupplierCode}, Item Code: {ItemCode}"

    End Function

    Public Function GetDoubleClickCommand() As String Implements IQueryBO.GetDoubleClickCommand
        Return "pbs.BO.PO.SEV?SupplierCode=[SupplierCode]&ItemCode=[ItemCode]&$Action=View"
    End Function

    Public Function GetMyQD() As SQLBuilder.QD Implements IQueryBO.GetMyQD
        Return Nothing
    End Function

    Public Function GetMyTitle() As String Implements IQueryBO.GetMyTitle
        Return String.Format("Supplier Evaluation at {0}", _selectedDate)
    End Function

    Public Function GetSelectCommand() As String Implements IQueryBO.GetSelectCommand
        Return String.Empty
    End Function

    Public Function GetSelectionChangedCommand() As String Implements IQueryBO.GetSelectionChangedCommand
        Return String.Empty
    End Function

    Public Function GetVariables() As System.Collections.Generic.Dictionary(Of String, String) Implements IQueryBO.GetVariables

    End Function

    Public Sub InvalidateCacheList() Implements IQueryBO.InvalidateCacheList

    End Sub

    Public Sub SetParameters(pDic As System.Collections.Generic.Dictionary(Of String, String)) Implements IQueryBO.SetParameters
        '_supplierCode = pDic.GetValueByKey("SupplierCode", String.Empty)
        '_itemCode = pDic.GetValueByKey("ItemCode", String.Empty)
    End Sub

    Public Function Syntax() As String Implements IQueryBO.Syntax
        Return <syntax>
                   pbs.BO.SupplierEvaluation?EffectiveDate=[EffectiveDate]
               </syntax>
    End Function

    Public Sub UpdateCurrentLine(pLine As Object) Implements IQueryBO.UpdateCurrentLine

    End Sub

    Public Sub UpdateQD(pQD As SQLBuilder.QD) Implements IQueryBO.UpdateQD

    End Sub

    Public Sub UpdateSelectedLines(pLines As System.Collections.IEnumerable) Implements IQueryBO.UpdateSelectedLines

    End Sub

    Public Sub ZReset() Implements IQueryBO.ZReset

    End Sub

    Public Function CanExecute(cmd As String) As Boolean? Implements Helper.Interfaces.ISupportCommandAuthorization.CanExecute

    End Function

#End Region

#Region "ISupportScripts"
    'Selection date button
    Private Function SelectPeriod_Imp() As UITasks
        Dim ret = New UITasks(Me)
        ret.IconName = "Find/Find"
        ret.AddCallMethod(1, "SelectDate")
        ret.RefreshUIWhenFinish = True

        Return ret
    End Function

    Private Sub SelectDate()
        Dim newDate = pbs.Helper.UIServices.ValueSelectorService.SelectValue(LinkCode.Calendar, ResStr(ResStrConst.SelectItemText("Date")), String.Empty)
        If Not String.IsNullOrEmpty(newDate) Then
            _effectiveDate.Text = newDate
        End If

    End Sub


    'Next period button
    Private Function NextPeriod_Imp() As UITasks
        Dim ret As New UITasks(Me)
        ret.IconName = "Next"
        ret.AddCallMethod(1, "NextPeriod")
        ret.RefreshUIWhenFinish = True

        Return ret
    End Function

    Private Sub NextPeriod()
        _effectiveDate.Date = _effectiveDate.Date.AddMonths(1)
    End Sub

    'Previous period button
    Private Function PreviousPeriod_Imp() As UITasks
        Dim ret As New UITasks(Me)
        ret.IconName = "Prev"
        ret.AddCallMethod(1, "PrevPeriod")
        ret.RefreshUIWhenFinish = True

        Return ret
    End Function

    Private Sub PrevPeriod()
        _effectiveDate.Date = _effectiveDate.Date.AddMonths(-1)
    End Sub

    ''Amend button
    'Private Function Amend_Imp() As UITasks
    '    Dim ret As New UITasks(Me)
    '    ret.IconName = "Amend"
    '    ret.AddCallMethod(1, "Amend")
    '    ret.RefreshUIWhenFinish = True

    '    Return ret
    'End Function

    'Private Sub Amend()
    '    Dim cmm = New pbsCmdArgs(String.Format("pbs.BO.PO.SEV?SupplierCode={0}&ItemCode={1}&Action=Amend", _supplierCode, _itemCode))
    '    pbs.Helper.UIServices.RunURLService.Run(cmm)
    'End Sub

    Public Function GetScriptDictionary() As Dictionary(Of String, UITasks) Implements ISupportScripts.GetScriptDictionary
        Dim ret As New Dictionary(Of String, UITasks)
        'ret.Add("Amend", Amend_Imp)
        ret.Add("Next", NextPeriod_Imp)
        ret.Add("Filter", SelectPeriod_Imp)
        ret.Add("Previous", PreviousPeriod_Imp)
        Return ret
    End Function

#End Region


#Region "Interfaces.ISupportListEdit"

    Public Sub Post() Implements Interfaces.ISupportListEdit.Post

    End Sub

    Private list As List(Of Variable)

    Public Sub zPost() Implements Interfaces.ISupportListEdit.zPost
        If list IsNot Nothing Then

            For Each itm In list
                'If itm.IsDirty Then
                Dim original As PO.SEV = Nothing
                'original.SupplierCode = itm.SupplierCode
                'original.ItemCode = itm.ItemCode
                'original.EffectiveDate = itm.EffectiveDate
                'original.Suspended = itm.Suspended
                'original.Value0 = itm.Value0
                'original.Value1 = itm.Value1
                'original.Value2 = itm.Value2
                'original.Value3 = itm.Value3
                'original.Value4 = itm.Value4
                'original.Value5 = itm.Value5
                'original.Value6 = itm.Value6
                'original.Value7 = itm.Value7
                'original.Value8 = itm.Value8
                'original.Value9 = itm.Value9
                'original.Notes = itm.Notes
                'original.Save()
                'End If
            Next
        End If
    End Sub

#End Region

#Region "Variable"
    Class Variable

        Private _supplierCode As String = String.Empty
        Public ReadOnly Property SupplierCode() As String
            Get
                Return _supplierCode
            End Get
        End Property

        Private _itemCode As String = String.Empty
        Public ReadOnly Property ItemCode() As String
            Get
                Return _itemCode
            End Get
        End Property

        'Private _effectiveDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        'Public Property EffectiveDate() As String
        '    Get
        '        Return _effectiveDate.Text
        '    End Get
        '    Set(ByVal value As String)
        '        If Not _effectiveDate.Equals(value) Then
        '            _effectiveDate.Text = value
        '            PropertyHasChanged("EffectiveDate")
        '        End If
        '    End Set
        'End Property

        'Private _suspended As String = String.Empty
        'Public Property Suspended() As String
        '    Get
        '        Return _suspended
        '    End Get
        '    Set(ByVal value As String)
        '        If Not _suspended.Equals(value) Then
        '            _suspended = value
        '            PropertyHasChanged("Suspended")
        '        End If
        '    End Set
        'End Property

        'Private _value0 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        'Public Property Value0() As String
        '    Get
        '        Return _value0.Text
        '    End Get
        '    Set(ByVal value As String)
        '        If Not _value0.Equals(value) Then
        '            _value0.Text = value
        '            PropertyHasChanged("Value0")
        '        End If
        '    End Set
        'End Property

        'Private _value1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        'Public Property Value1() As String
        '    Get
        '        Return _value1.Text
        '    End Get
        '    Set(ByVal value As String)
        '        If Not _value1.Equals(value) Then
        '            _value1.Text = value
        '            PropertyHasChanged("Value1")
        '        End If
        '    End Set
        'End Property

        'Private _value2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        'Public Property Value2() As String
        '    Get
        '        Return _value2.Text
        '    End Get
        '    Set(ByVal value As String)
        '        If Not _value2.Equals(value) Then
        '            _value2.Text = value
        '            PropertyHasChanged("Value2")
        '        End If
        '    End Set
        'End Property

        'Private _value3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        'Public Property Value3() As String
        '    Get
        '        Return _value3.Text
        '    End Get
        '    Set(ByVal value As String)
        '        If Not _value3.Equals(value) Then
        '            _value3.Text = value
        '            PropertyHasChanged("Value3")
        '        End If
        '    End Set
        'End Property

        'Private _value4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        'Public Property Value4() As String
        '    Get
        '        Return _value4.Text
        '    End Get
        '    Set(ByVal value As String)
        '        If Not _value4.Equals(value) Then
        '            _value4.Text = value
        '            PropertyHasChanged("Value4")
        '        End If
        '    End Set
        'End Property

        'Private _value5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        'Public Property Value5() As String
        '    Get
        '        Return _value5.Text
        '    End Get
        '    Set(ByVal value As String)
        '        If Not _value5.Equals(value) Then
        '            _value5.Text = value
        '            PropertyHasChanged("Value5")
        '        End If
        '    End Set
        'End Property

        'Private _value6 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        'Public Property Value6() As String
        '    Get
        '        Return _value6.Text
        '    End Get
        '    Set(ByVal value As String)
        '        If Not _value6.Equals(value) Then
        '            _value6.Text = value
        '            PropertyHasChanged("Value6")
        '        End If
        '    End Set
        'End Property

        'Private _value7 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        'Public Property Value7() As String
        '    Get
        '        Return _value7.Text
        '    End Get
        '    Set(ByVal value As String)
        '        If Not _value7.Equals(value) Then
        '            _value7.Text = value
        '            PropertyHasChanged("Value7")
        '        End If
        '    End Set
        'End Property

        'Private _value8 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        'Public Property Value8() As String
        '    Get
        '        Return _value8.Text
        '    End Get
        '    Set(ByVal value As String)
        '        If Not _value8.Equals(value) Then
        '            _value8.Text = value
        '            PropertyHasChanged("Value8")
        '        End If
        '    End Set
        'End Property

        'Private _value9 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        'Public Property Value9() As String
        '    Get
        '        Return _value9.Text
        '    End Get
        '    Set(ByVal value As String)
        '        If Not _value9.Equals(value) Then
        '            _value9.Text = value
        '            PropertyHasChanged("Value9")
        '        End If
        '    End Set
        'End Property

        'Private _notes As String = String.Empty
        'Public Property Notes() As String
        '    Get
        '        Return _notes
        '    End Get
        '    Set(ByVal value As String)
        '        If Not _notes.Equals(value) Then
        '            _notes = value
        '            PropertyHasChanged("Notes")
        '        End If
        '    End Set
        'End Property




        



    End Class
#End Region

End Class
