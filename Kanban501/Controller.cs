using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Kanban501
{
    public delegate void ObserverDel(string data);
    public class Controller
    {

        private TaskManagerM taskManager;

        private List<ObserverDel> observersList;

        private State state;



    }
}
