# LibProgressMonitor

## 概要

使用感は SWT の ProgressMonitor と似ています。似てはいますが、起動方法が異なります。

参考までに対応表です:

| Eclipse, SWT | LibProgressMonitor |
| ------------ | ------------------ |
| [Class ProgressMonitorDialog](https://help.eclipse.org/kepler/index.jsp?topic=%2Forg.eclipse.platform.doc.isv%2Freference%2Fapi%2Forg%2Feclipse%2Fjface%2Fdialogs%2FProgressMonitorDialog.html) | [WaitForm](@ref kenjiuno.LibProgressMonitor.WaitForm) |
| [Interface IProgressMonitor](https://help.eclipse.org/mars/index.jsp?topic=%2Forg.eclipse.platform.doc.isv%2Freference%2Fapi%2Forg%2Feclipse%2Fcore%2Fruntime%2FIProgressMonitor.html) | [IProgressMonitor](@ref kenjiuno.LibProgressMonitor.Interfaces.IProgressMonitor) |
| [Interface IRunnableWithProgress](https://help.eclipse.org/kepler/index.jsp?topic=%2Forg.eclipse.platform.doc.isv%2Freference%2Fapi%2Forg%2Feclipse%2Fjface%2Foperation%2FIRunnableWithProgress.html) | [IRunnableWithProgress](@ref kenjiuno.LibProgressMonitor.Interfaces.IRunnableWithProgress) |
| [Class NullProgressMonitor](https://help.eclipse.org/luna/index.jsp?topic=%2Forg.eclipse.platform.doc.isv%2Freference%2Fapi%2Forg%2Feclipse%2Fcore%2Fruntime%2FNullProgressMonitor.html) | [NullProgressMonitor](@ref kenjiuno.LibProgressMonitor.Utils.NullProgressMonitor) |
| なし | [ProgressMonitorDelegateProxy](@ref kenjiuno.LibProgressMonitor.Utils.ProgressMonitorDelegateProxy) |
| [Class ProgressMonitorWrapper](https://help.eclipse.org/mars/index.jsp?topic=%2Forg.eclipse.platform.doc.isv%2Freference%2Fapi%2Forg%2Feclipse%2Fcore%2Fruntime%2FProgressMonitorWrapper.html) | [ProgressMonitorWrapper](@ref kenjiuno.LibProgressMonitor.Utils.ProgressMonitorWrapper) |
| [Class SubProgressMonitor](https://help.eclipse.org/mars/index.jsp?topic=%2Forg.eclipse.platform.doc.isv%2Freference%2Fapi%2Forg%2Feclipse%2Fcore%2Fruntime%2FSubProgressMonitor.html) | [SubProgressMonitor](@ref kenjiuno.LibProgressMonitor.Utils.SubProgressMonitor) |

## 起動例

```cs
try
{
	using (var form = new WaitForm())
	{
		form.run(
			fork: true,
			cancelable: true,
			runnable: new Runnable()
		);
	}
}
catch (Exception ex)
{
	MessageBox.Show(ex.ToString());
}
```
