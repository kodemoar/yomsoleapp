# Yomsole App

A demo implementation of some console application (written in C#), primarily aiming to function as an assistive accompaniment for common terminal activities.

For complex implementations, you should best use a command-line parser (which does all the heavy-lifting for you), 
like [NDesk.Options](https://nuget.org/packages/NDesk.Options/) or [Command Line Parser](https://archive.codeplex.com/?p=commandline).

Add `yom.exe` to your `PATH` for convenient command line access in Windows. Alternatively, `yomsole.exe` is also directly executable for basic commands.

<table>
	<tr>
		<td><strong>Commands<strong></td>
		<td><strong>Description</strong></td>
	</tr>
	<tr>
		<td><code>-v</code>, <code>--version</code></td>
		<td>Displays application version.</td>
	</tr>
    <tr>
		<td><code>base64 (-m|--mode)[=&lt;n&gt; &lt;value&gt;]</code></td>
		<td>Converts text to its base-64 string representation,<br>where <code>n</code> is either <code>encode</code> or <code>decode</code>.</td>
	</tr>
	<tr>
		<td>
			<code>today [<a href="https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.85).aspx" target="_blank">DateTime pattern</a>]</code>
		</td>
		<td>Displays today's date and time.</td>
	</tr>
    <tr>
		<td><code>translate-color &lt;colorHex&gt;</code></td>
		<td>Converts Hex to RGB color structure.</td>
	</tr>
	<tr>
		<td><code>uptime</code></td>
		<td>Displays time elapsed since last Windows (re)boot.</td>
	</tr>
	<tr>
		<td>
			<code>shutdown &lt;minsUntilShutdown&gt;</code><br>
            <code>shutdown (-a|--abort)</code>
		</td>
		<td>Schedules a shutdown operation or cancels active schedule.</td>
	</tr>
</table>

Example call:
```batch
yom shutdown 15
```

### Main features

 - Base64 converter
 - Quick color converter
 - Time elapsed since last system (re)boot
 - Today's date and time
 - Windows shutdown scheduler
 - and more to come...

### TO-DOs
 - Implement further viewing of "system boot time" in event viewer. Passing the following Event Log XML query when used in conjunction with the `/f` switch.
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