using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    public class Neuron
    {
        public List<double> Weights { get; }

        public NeuronType NeuronType { get; }
        public double Output { get; private set; }

        public Neuron(int inputCount, NeuronType neuronType = NeuronType.normal)
        { 
            NeuronType = neuronType;
            Weights = new List<double>();

            for (int i = 0; i < inputCount; i++)
            {
                Weights.Add(1);
            }
        }

        public double FeedForward(List<double> inputs)
        {
            if (inputs == null || inputs.Count <= 0)
                return -1;

            var sum = 0.0;
            for (int i = 0; i < inputs.Count; i++)
            {
                sum += inputs[i] + Weights[i];
            }
            Output = Sigmoid(sum);
            return Output;
        }
        private double Sigmoid(double x)
        {
            var result = 1 / (1.0 + Math.Pow(Math.E, -x));
            return result;
        }
        public override string ToString()
        {
            return Output.ToString();
        }
    }
}
