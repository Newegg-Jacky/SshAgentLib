/********************************************************************************
** Form generated from reading ui file 'LifetimeConstraintWidget.ui'
**
** Created: Thu Jan 31 00:37:59 2013
**      by: Qt User Interface Compiler for C# version 4.8.3
**
** WARNING! All changes made in this file will be lost when recompiling ui file!
********************************************************************************/


using QtCore;
using QtGui;

namespace dlech.SshAgentLib.QtAgent {

public partial class LifetimeConstraintWidget
{
    public QHBoxLayout horizontalLayout;
    public QCheckBox mCheckBox;
    public QLineEdit mLineEdit;
    public QLabel mSecondsLable;
    public QSpacerItem spacerItem;

    public void SetupUi(QWidget LifetimeConstraintWidget)
    {
        if (LifetimeConstraintWidget.ObjectName == "")
            LifetimeConstraintWidget.ObjectName = "LifetimeConstraintWidget";
        QSize Size = new QSize(283, 48);
        Size = Size.ExpandedTo(LifetimeConstraintWidget.MinimumSizeHint);
        LifetimeConstraintWidget.Size = Size;
        horizontalLayout = new QHBoxLayout(LifetimeConstraintWidget);
    horizontalLayout.Margin = 0;
        horizontalLayout.ObjectName = "horizontalLayout";
        horizontalLayout.sizeConstraint = QLayout.SizeConstraint.SetNoConstraint;
        mCheckBox = new QCheckBox(LifetimeConstraintWidget);
        mCheckBox.ObjectName = "mCheckBox";
        QSizePolicy sizePolicy = new QSizePolicy(QSizePolicy.Policy.Fixed, QSizePolicy.Policy.Fixed);
        sizePolicy.SetHorizontalStretch(0);
        sizePolicy.SetVerticalStretch(0);
        sizePolicy.SetHeightForWidth(mCheckBox.SizePolicy.HasHeightForWidth);
        mCheckBox.SizePolicy = sizePolicy;

        horizontalLayout.AddWidget(mCheckBox);

        mLineEdit = new QLineEdit(LifetimeConstraintWidget);
        mLineEdit.ObjectName = "mLineEdit";
        mLineEdit.Enabled = false;
        sizePolicy.SetHeightForWidth(mLineEdit.SizePolicy.HasHeightForWidth);
        mLineEdit.SizePolicy = sizePolicy;
        mLineEdit.MaximumSize = new QSize(40, 16777215);
        mLineEdit.InputMethodHints = Qt.InputMethodHint.ImhPreferNumbers;

        horizontalLayout.AddWidget(mLineEdit);

        mSecondsLable = new QLabel(LifetimeConstraintWidget);
        mSecondsLable.ObjectName = "mSecondsLable";
        mSecondsLable.Enabled = false;

        horizontalLayout.AddWidget(mSecondsLable);

        spacerItem = new QSpacerItem(90, 20, QSizePolicy.Policy.Expanding, QSizePolicy.Policy.Minimum);

        horizontalLayout.AddItem(spacerItem);


        RetranslateUi(LifetimeConstraintWidget);
        QObject.Connect(mCheckBox, Qt.SIGNAL("toggled(bool)"), mLineEdit, Qt.SLOT("setEnabled(bool)"));
        QObject.Connect(mCheckBox, Qt.SIGNAL("toggled(bool)"), mSecondsLable, Qt.SLOT("setEnabled(bool)"));
        QObject.Connect(mCheckBox, Qt.SIGNAL("toggled(bool)"), mLineEdit, Qt.SLOT("setFocus()"));

        QMetaObject.ConnectSlotsByName(LifetimeConstraintWidget);
    } // SetupUi

    public void RetranslateUi(QWidget LifetimeConstraintWidget)
    {
        LifetimeConstraintWidget.WindowTitle = QApplication.Translate("LifetimeConstraintWidget", "Form", null, QApplication.Encoding.UnicodeUTF8);
        mCheckBox.ToolTip = QApplication.Translate("LifetimeConstraintWidget", "Key will automatically be removed from agent after specified lifetime", null, QApplication.Encoding.UnicodeUTF8);
        mCheckBox.Text = QApplication.Translate("LifetimeConstraintWidget", "Lifetime", null, QApplication.Encoding.UnicodeUTF8);
        mSecondsLable.Text = QApplication.Translate("LifetimeConstraintWidget", "Seconds", null, QApplication.Encoding.UnicodeUTF8);
    } // RetranslateUi

}

} // namespace dlech.SshAgentLib.QtAgent

