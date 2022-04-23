using DBCAnalysis.Core.BeanManage;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.BitTimingDefinition;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.CommentDefinitions;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.EnvironmentVariableDefinitions;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.NodeDefinitions;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.SignalTypeAndSignalGroupDefinitions;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.UserDefinedAttributeDefinitions;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.ValueTableDefinitions;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.VersionAndNewSymbolSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine
{
    class QueryAnalysisMachineObject
    {
        /// <summary>
        /// 获取BitTimingAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetBitTimingAnalysisMachine()
        {
            return new BitTimingAnalysisMachine();
        }

        /// <summary>
        /// 获取CommentAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetCommentAnalysisMachine()
        {
            return new CommentAnalysisMachine();
        }

        /// <summary>
        /// 获取EnvironmentVariableAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetEnvironmentVariableAnalysisMachine()
        {
            return new EnvironmentVariableAnalysisMachine();
        }

        /// <summary>
        /// 获取EnvironmentVariableDataAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetEnvironmentVariableDataAnalysisMachine()
        {
            return new EnvironmentVariableDataAnalysisMachine();
        }

        /// <summary>
        /// 获取ValueDescriptionsForEnvVarAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetValueDescriptionsForEnvVarAnalysisMachine()
        {
            return new ValueDescriptionsForEnvVarAnalysisMachine();
        }

        /// <summary>
        /// 获取MessageAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetMessageAnalysisMachine()
        {
            return new MessageAnalysisMachine();
        }

        /// <summary>
        /// 获取MessageTransmitterAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetMessageTransmitterAnalysisMachine()
        {
            return new MessageTransmitterAnalysisMachine();
        }

        /// <summary>
        /// 获取SignalAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetSignalAnalysisMachine()
        {
            return new SignalAnalysisMachine();
        }

        /// <summary>
        /// 获取SignalExtendedValueTypeListAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetSignalExtendedValueTypeListAnalysisMachine()
        {
            return new SignalExtendedValueTypeListAnalysisMachine();
        }

        /// <summary>
        /// 获取ValueDescriptionsForSignalAanlysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetValueDescriptionsForSignalAanlysisMachine()
        {
            return new ValueDescriptionsForSignalAanlysisMachine();
        }

        /// <summary>
        /// 获取NodeAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetNodeAnalysisMachine()
        {
            return new NodeAnalysisMachine();
        }

        /// <summary>
        /// 获取SignalGroupsAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetSignalGroupsAnalysisMachine()
        {
            return new SignalGroupsAnalysisMachine();
        }

        /// <summary>
        /// 获取SignalTypeAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetSignalTypeAnalysisMachine()
        {
            return new SignalTypeAnalysisMachine();
        }

        /// <summary>
        /// 获取SignalTypeRefAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetSignalTypeRefAnalysisMachine()
        {
            return new SignalTypeRefAnalysisMachine();
        }

        /// <summary>
        /// 获取AttributeDefaultAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetAttributeDefaultAnalysisMachine()
        {
            return new AttributeDefaultAnalysisMachine();
        }

        /// <summary>
        /// 获取AttributeDefinitionAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetAttributeDefinitionAnalysisMachine()
        {
            return new AttributeDefinitionAnalysisMachine();
        }

        /// <summary>
        /// 获取AttributeValueForObjectAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetAttributeValueForObjectAnalysisMachine()
        {
            return new AttributeValueForObjectAnalysisMachine();
        }

        /// <summary>
        /// 获取ValueTableAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetValueTableAnalysisMachine()
        {
            return new ValueTableAnalysisMachine();
        }

        /// <summary>
        /// 获取NewSymbolAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetNewSymbolAnalysisMachine()
        {
            return new NewSymbolAnalysisMachine();
        }

        /// <summary>
        /// 获取VersionAnalysisMachine解析器。
        /// </summary>
        /// <returns></returns>
        public static AnalysisMachine GetVersionAnalysisMachine()
        {
            return new VersionAnalysisMachine();
        }
    }
}
