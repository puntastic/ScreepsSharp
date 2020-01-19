module.exports =
{
	LoadModule: function (name)
	{
		let message;
		try { return require(name); }
		catch (ex)
		{
			message = `Could not load module ${name}: `;
			if (ex.toString)
			{
				message += ex.toString();
				return null;
			}

			if (!ex.message)
			{
				message += `Unknown Error:\n`;
				return null;
			}

			message += ex.message;
			if (!ex.message.startsWith('Error: Unknown module')) { return null; }
			if (!ex.stack) { return null; }


			message += `\n ${ex.stack}`;
		}
		finally
		{
			if (message) { console.log(message); }
		}
	}
}