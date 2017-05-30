Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports pbs.Helper

Namespace PO

    <Serializable()> _
    Public Class AWDs
        Inherits Csla.BusinessListBase(Of AWDs, AWD)

#Region " Business Methods"
        Friend _parent As AWH = Nothing

        Protected Overrides Function AddNewCore() As Object
            If _parent IsNot Nothing Then
                Dim theNewLine = AWD.NewAWDChild(_parent.AwardNo)
                AddNewLine(theNewLine)
                theNewLine.CheckRules()
                Return theNewLine
            Else
                Return MyBase.AddNewCore
            End If
        End Function

        Friend Sub AddNewLine(ByVal _line As AWD)
            If _line Is Nothing Then Exit Sub

            'get the next line number
            Dim nextnumber As Integer = 1
            If Me.Count > 0 Then
                Dim allNumbers = (From line In Me Select line.LineNo).ToList
                nextnumber = allNumbers.Max + 1
            End If

            _line._LineNo = nextnumber

            'Populate _line with info from parent here

            Me.Add(_line)

        End Sub

#End Region
#Region " Factory Methods "

        Friend Shared Function NewAWDs(ByVal pParent As AWH) As AWDs
            Return New AWDs(pParent)
        End Function

        Friend Shared Function GetAWDs(ByVal dr As SafeDataReader, ByVal parent As AWH) As AWDs
            Dim ret = New AWDs(dr, parent)
            ret.MarkAsChild()
            Return ret
        End Function

        Private Sub New(ByVal parent As AWH)
            _parent = parent
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As SafeDataReader, ByVal parent As AWH)
            _parent = parent
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region ' Factory Methods
#Region " Data Access "

        Private Sub Fetch(ByVal dr As SafeDataReader)
            RaiseListChangedEvents = False

            Dim suppressChildValidation = True
            While dr.Read()
                Dim Line = AWD.GetChildAWD(dr)
                Me.Add(Line)
            End While

            RaiseListChangedEvents = True
        End Sub

        Friend Sub Update(ByVal cn As SqlConnection, ByVal parent As AWH)
            RaiseListChangedEvents = False

            ' loop through each deleted child object
            For Each deletedChild As AWD In DeletedList
                deletedChild._DTB = parent._DTB
                deletedChild.DeleteSelf(cn)
            Next
            DeletedList.Clear()

            ' loop through each non-deleted child object
            For Each child As AWD In Me
                child._DTB = parent._DTB
                child._awardNo = parent._awardNo
                'child.OrderNo = parent.OrderNo
                If child.IsNew Then
                    child.Insert(cn)
                Else
                    child.Update(cn)
                End If
            Next

            RaiseListChangedEvents = True
        End Sub

#End Region ' Data Access                   
    End Class

End Namespace