# LibProgressMonitor

[ドキュメント](https://hiraokahypertools.github.io/LibProgressMonitor/)

* 注意点
form.run(
		fork: true,
		cancelable: true,
		runnable: new Runnable()
);
　fork:	true・・・非同期
 	false・・・メインスレッド上で実行のため、Contlorは使えない
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

example 2

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
				runnable: new RunnableWithProgressProxy(
					monitor =>
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
				)
			);
		}
	}
	catch (Exception ex)
	{
		MessageBox.Show(ex.ToString());
	}
}

class RunnableWithProgressProxy : IRunnableWithProgress
{
	private readonly Action<IProgressMonitor> action;

	public RunnableWithProgressProxy(Action<IProgressMonitor> action)
	{
		this.action = action;
	}

	public void run(IProgressMonitor monitor)
	{
		action(monitor);
	}
}
```
