using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;

namespace AvaloniaApplication1.Behaviors
{
    internal class DataGridSelectionChangedBehavior
    {
        // 1. 定义附加属性：创建一个可以在任何Control上附加的Command属性
        public static readonly AttachedProperty<ICommand> CommandProperty =
            AvaloniaProperty.RegisterAttached<DataGridSelectionChangedBehavior, DataGrid, ICommand>(
                "Command");  // 属性名称为 "Command"

        // 2. 定义命令参数属性：用于传递参数给命令
        public static readonly AttachedProperty<object> CommandParameterProperty =
            AvaloniaProperty.RegisterAttached<DataGridSelectionChangedBehavior, DataGrid, object>(
                "CommandParameter");  // 属性名称为 "CommandParameter"

        // 3. 静态构造函数：在类首次使用时执行一次
        static DataGridSelectionChangedBehavior()
        {
            // 4. 监听CommandProperty的变化
            CommandProperty.Changed.AddClassHandler<DataGrid>((control, e) =>
            {
                // 当Command属性被设置或更改时
                if (e.NewValue is ICommand)
                {  
                    control.SelectionChanged += Control_SelectionChanged;  // 订阅点击事件
                }
                else
                {
                    control.SelectionChanged -= Control_SelectionChanged;  // 取消订阅点击事件
                }
            });
        }

        private static void Control_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid control)
            {
                // 获取附加的命令
                var command = GetCommand(control);
                // 获取附加的命令参数
                var parameter = GetCommandParameter(control);

                // 检查命令是否可以执行
                if (command?.CanExecute(parameter) == true)
                {
                    command.Execute(parameter);  // 执行命令并传递参数
                    e.Handled = true;  // 标记事件已处理，阻止事件冒泡
                } 
            }
        } 
        // 6. Command属性的Get/Set方法
        public static ICommand GetCommand(Control obj) => obj.GetValue(CommandProperty);
        public static void SetCommand(Control obj, ICommand value) => obj.SetValue(CommandProperty, value);

        // 7. CommandParameter属性的Get/Set方法
        public static object GetCommandParameter(Control obj) => obj.GetValue(CommandParameterProperty);
        public static void SetCommandParameter(Control obj, object value) => obj.SetValue(CommandParameterProperty, value);
    }
}
