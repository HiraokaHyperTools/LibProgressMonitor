# LibProgressMonitor

使用例

```cs
		private void button1_Click(object sender, EventArgs e)
		{
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
		}

		class Runnable : IRunnableWithProgress
		{
			public void run(IProgressMonitor monitor)
			{
				monitor.beginTask("重たい処理を実行", 100);

				monitor.subTask("まだまだ始まったばかり…");

				monitor.worked(10); Thread.Sleep(1000); if (monitor.isCanceled()) { throw new Exception("キャンセルされたー"); }
				monitor.worked(10); Thread.Sleep(1000); if (monitor.isCanceled()) { throw new Exception("キャンセルされたー"); }
				monitor.worked(10); Thread.Sleep(1000); if (monitor.isCanceled()) { throw new Exception("キャンセルされたー"); }
				monitor.worked(10); Thread.Sleep(1000); if (monitor.isCanceled()) { throw new Exception("キャンセルされたー"); }
				monitor.worked(10); Thread.Sleep(1000); if (monitor.isCanceled()) { throw new Exception("キャンセルされたー"); }

				monitor.subTask("半分ぐらい?");

				monitor.worked(10); Thread.Sleep(1000); if (monitor.isCanceled()) { throw new Exception("キャンセルされたー"); }
				monitor.worked(10); Thread.Sleep(1000); if (monitor.isCanceled()) { throw new Exception("キャンセルされたー"); }
				monitor.worked(10); Thread.Sleep(1000); if (monitor.isCanceled()) { throw new Exception("キャンセルされたー"); }

				monitor.done();
			}
		}
```
