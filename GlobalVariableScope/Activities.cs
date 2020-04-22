using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;

namespace GlobalVariableScope
{
    public class NewVariable : CodeActivity
    {
        data my_data = data.Instance;

        [Category("Input")]
        [RequiredArgument]
        public InArgument<String> VariableName { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<object> VariableValue { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            String CreateVariableKey = VariableName.Get(context);
            object CreateVariableValue = VariableValue.Get(context);
            my_data.AddData(CreateVariableKey, CreateVariableValue);
        }
    }
    public class RetrieveVariable : CodeActivity
    {
        data my_data = data.Instance;
        [Category("Input")]
        [RequiredArgument]
        public InArgument<String> VariableName { get; set; }

        [Category("Output")]
        public OutArgument<object> VariableOutput { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            String CreateVariableKey = VariableName.Get(context);
            VariableOutput.Set(context, my_data.RetrieveData(CreateVariableKey));
        }
    }
    public class DisposeVariable : CodeActivity
    {
        data my_data = data.Instance;
        [Category("Input")]
        [RequiredArgument]
        public InArgument<String> VariableName { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            String CreateVariableKey = VariableName.Get(context);
            my_data.DeleteData(CreateVariableKey);
        }
    }
    public class UpdateVariable : CodeActivity
    {
        data my_data = data.Instance;
        [Category("Input")]
        [RequiredArgument]
        public InArgument<String> VariableName { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<object> VariableNewValue { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            String CreateVariableKey = VariableName.Get(context);
            object CreateVariableNewValue = VariableNewValue.Get(context);
            my_data.UpdateData(CreateVariableKey, CreateVariableNewValue);
        }
    }
    public class PrintKey : CodeActivity
    {
        data my_data = data.Instance;
        [Category("Output")]
        public OutArgument<object> VariableOutput { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            VariableOutput.Set(context, my_data.PrintData());
        }
    }
}