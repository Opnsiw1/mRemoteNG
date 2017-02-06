﻿using log4net;
using mRemoteNG.Messages;
using mRemoteNG.Messages.MessageWriters;
using NSubstitute;
using NUnit.Framework;

namespace mRemoteNGTests.Messages.MessageWriters
{
    public class TextLogMessageWriterTests
    {
        private TextLogMessageWriter _messageWriter;
        private ILog _log4NetLogger;

        [SetUp]
        public void Setup()
        {
            _log4NetLogger = Substitute.For<ILog>();
            _messageWriter = new TextLogMessageWriter(_log4NetLogger);
        }

        [Test]
        public void MultipleMessagesPassedToLog4Net()
        {
            var message1 = Substitute.For<IMessage>();
            var message2 = Substitute.For<IMessage>();
            message1.Class.Returns(MessageClass.InformationMsg);
            message2.Class.Returns(MessageClass.InformationMsg);
            _messageWriter.Print(message1);
            _messageWriter.Print(message2);
            _log4NetLogger.ReceivedWithAnyArgs(2).Info("");
        }

        [Test]
        public void InfoMessagesPassedToLog4Net()
        {
            var message = Substitute.For<IMessage>();
            message.Class.Returns(MessageClass.InformationMsg);
            _messageWriter.Print(message);
            _log4NetLogger.ReceivedWithAnyArgs(1).Info("");
        }

        [Test]
        public void DebugMessagesPassedToLog4Net()
        {
            var message = Substitute.For<IMessage>();
            message.Class.Returns(MessageClass.DebugMsg);
            _messageWriter.Print(message);
            _log4NetLogger.ReceivedWithAnyArgs(1).Debug("");
        }

        [Test]
        public void WarningMessagesPassedToLog4Net()
        {
            var message = Substitute.For<IMessage>();
            message.Class.Returns(MessageClass.WarningMsg);
            _messageWriter.Print(message);
            _log4NetLogger.ReceivedWithAnyArgs(1).Warn("");
        }

        [Test]
        public void ErrorMessagesPassedToLog4Net()
        {
            var message = Substitute.For<IMessage>();
            message.Class.Returns(MessageClass.ErrorMsg);
            _messageWriter.Print(message);
            _log4NetLogger.ReceivedWithAnyArgs(1).Error("");
        }

        [Test]
        public void InfoMessagesNotPassedToLog4NetIfTurnedOff()
        {
            var message = Substitute.For<IMessage>();
            message.Class.Returns(MessageClass.InformationMsg);
            _messageWriter.PrintInfoMessages = false;
            _messageWriter.Print(message);
            _log4NetLogger.DidNotReceiveWithAnyArgs().Info("");
        }

        [Test]
        public void DebugMessagesNotPassedToLog4NetIfTurnedOff()
        {
            var message = Substitute.For<IMessage>();
            message.Class.Returns(MessageClass.DebugMsg);
            _messageWriter.PrintDebugMessages = false;
            _messageWriter.Print(message);
            _log4NetLogger.DidNotReceiveWithAnyArgs().Debug("");
        }

        [Test]
        public void WarningMessagesNotPassedToLog4NetIfTurnedOff()
        {
            var message = Substitute.For<IMessage>();
            message.Class.Returns(MessageClass.WarningMsg);
            _messageWriter.PrintWarningMessages = false;
            _messageWriter.Print(message);
            _log4NetLogger.DidNotReceiveWithAnyArgs().Warn("");
        }

        [Test]
        public void ErrorMessagesNotPassedToLog4NetIfTurnedOff()
        {
            var message = Substitute.For<IMessage>();
            message.Class.Returns(MessageClass.ErrorMsg);
            _messageWriter.PrintErrorMessages = false;
            _messageWriter.Print(message);
            _log4NetLogger.DidNotReceiveWithAnyArgs().Error("");
        }
    }
}