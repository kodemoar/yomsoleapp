# Yomsole App

> Random console application to mess around with your terminals.

Add `yom.exe` to your `PATH` for convenient command line access in Windows. Alternatively, `yomsole.exe` is also directly executable for basic commands.

<table>
	<tr>
		<td><strong>Commands<strong></td>
		<td><strong>Description</strong></td>
	</tr>
	<tr>
		<td><code>--version</code></td>
		<td>Displays application version.</td>
	</tr>	
	<tr>
		<td>
			<code>clear</code>,
			<code>cls</code>
		</td>
		<td>Clears console window.</td>
	</tr>
	<tr>
		<td>
			<code>exit</code>
		</td>
		<td>Exits console application.</td>
	</tr>
	<tr>
		<td>
			<code>
			today [<a href="https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.85).aspx" target="_blank">DateTime pattern</a>]
			</code>
		</td>
		<td>Displays today's date and time.</td>
	</tr>
	<tr>
		<td><code>uptime</code></td>
		<td>Displays time elapsed since last Windows (re)boot.</td>
	</tr>
	<tr>
		<td>
			<code>shutdown &lt;minsBeforeShutdown | abort&gt;</code><br>
		</td>
		<td>Schedules a shutdown operation or cancels active schedule.</td>
	</tr>
</table>

Example call:
```batch
yom shutdown 15
```

### Main features

 - Time elapsed since last system (re)boot
 - Windows shutdown scheduler
 - Today's date and time
 - and more to come...

### Pending TODOs
 - Implement further viewing of `system boot time` in event viewer. Passing the following Event Log XML query when used in conjunction with the `/f` switch.
	```xml
	<QueryList>
	  <Query Id="0" Path="System">
	    <Select Path="System">*[System[Provider[@Name='Microsoft-Windows-Winlogon'] and (EventID=7001) and TimeCreated[timediff(@SystemTime) &lt;= 43200000]]]</Select>
	  </Query>
	</QueryList>
	```
 - Support direct CLI executions for `shutdown scheduler` operation.

### Inspired by
- Windows Command Prompt and PowerShell
- [Git Bash](https://git-scm.com)

### Credits
- [Text to ASCII Art Generator (TAAG)](http://patorjk.com/software/taag) - for app version text style