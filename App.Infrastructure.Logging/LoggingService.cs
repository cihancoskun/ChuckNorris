using System;
using System.Linq;
using System.Threading.Tasks;

using NLog;

using App.Domain.RepositoryInterfaces;
using App.Domain.Entities;
using App.Infrastructure.Helpers; 

namespace App.Infrastructure.Logging
{
    public class LoggingService : NLog.Logger , ILoggingService
    {
        private static Logger _logger;
        private readonly IRepository<Log> _logRepo;

        public LoggingService(IRepository<Log> logRepo)
        {
            _logRepo = logRepo;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public Task<PagedList<Log>> GetLogs(int pageNumber)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var items = _logRepo.FindAll();

            long totalCount = items.Count();
            var totalPageCount = (int)Math.Ceiling(totalCount / (double)ConstHelper.PageSize);

            if (pageNumber > totalPageCount)
            {
                pageNumber = 1;
            }

            items = items.OrderByDescending(x => x.Id).Skip(ConstHelper.PageSize * (pageNumber - 1)).Take(ConstHelper.PageSize);

            return Task.FromResult(new PagedList<Log>(pageNumber, ConstHelper.PageSize, totalCount, items.ToList()));
        }

        public void Debug(string format, params object[] args)
        {
            if (!_logger.IsDebugEnabled) return;
            _logger.Debug(string.Format(format, args));
        }

        public void Error(string format, params object[] args)
        {
            if (!_logger.IsErrorEnabled) return;
            _logger.Error(string.Format(format, args));
        }

        public void Fatal(string format, params object[] args)
        {
            if (!_logger.IsFatalEnabled) return;
            _logger.Fatal(string.Format(format, args));
        }

        public void Info(string format, params object[] args)
        {
            if (!_logger.IsInfoEnabled) return;
            _logger.Info(string.Format(format, args));
        }

        public void Trace(string format, params object[] args)
        {
            if (!_logger.IsTraceEnabled) return;
            _logger.Trace(string.Format(format, args));
        }

        public void Warn(string format, params object[] args)
        {
            if (!_logger.IsWarnEnabled) return;
            _logger.Warn(string.Format(format, args));
        }

        public void Debug(Exception exception)
        {
            this.Debug(exception, string.Empty);
        }

        public void Error(Exception exception)
        {
            this.Error(exception, string.Empty);
        }

        public void Fatal(Exception exception)
        {
            this.Fatal(exception, string.Empty);
        }

        public void Info(Exception exception)
        {
            this.Info(exception, string.Empty);
        }

        public void Trace(Exception exception)
        {
            this.Trace(exception, string.Empty);
        }

        public void Warn(Exception exception)
        {
            this.Warn(exception, string.Empty);
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsDebugEnabled) return;
            var logEvent = LogUtility.GetLogEvent(_logger, LogLevel.Debug, exception, format, args);
            _logger.Log(typeof(LoggingService), logEvent);
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsErrorEnabled) return;
            var logEvent = LogUtility.GetLogEvent(_logger, LogLevel.Error, exception, format, args);
            _logger.Log(typeof(LoggingService), logEvent);
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsFatalEnabled) return;
            var logEvent = LogUtility.GetLogEvent(_logger, LogLevel.Fatal, exception, format, args);
            _logger.Log(typeof(LoggingService), logEvent);
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsInfoEnabled) return;
            var logEvent = LogUtility.GetLogEvent(_logger, LogLevel.Info, exception, format, args);
            _logger.Log(typeof(LoggingService), logEvent);
        }

        public void Trace(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsTraceEnabled) return;
            var logEvent = LogUtility.GetLogEvent(_logger, LogLevel.Trace, exception, format, args);
            _logger.Log(typeof(LoggingService), logEvent);
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsWarnEnabled) return;
            var logEvent = LogUtility.GetLogEvent(_logger, LogLevel.Warn, exception, format, args);
            _logger.Log(typeof(LoggingService), logEvent);
        }
    }
}
