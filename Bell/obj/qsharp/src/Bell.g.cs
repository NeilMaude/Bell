#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Quantum.Bell", "Set (desired : Result, q1 : Qubit) : ()", new string[] { }, "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs", 160L, 7L, 5L)]
[assembly: OperationDeclaration("Quantum.Bell", "BellTest (count : Int, initial : Result) : (Int, Int, Int)", new string[] { }, "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs", 464L, 20L, 5L)]
#line hidden
namespace Quantum.Bell
{
    public class Set : Operation<(Result,Qubit), QVoid>
    {
        public Set(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.X) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.X>();
            }
        }

        public override Func<(Result,Qubit), QVoid> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.Bell.Set", OperationFunctor.Body, _args);
                var __result__ = default(QVoid);
                try
                {
                    var (desired,q1) = _args;
#line 10 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                    var current = M.Apply<Result>(q1);
                    // The 'let' keyword binds mutable variables
#line 12 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                    if ((desired != current))
                    {
#line 14 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                        MicrosoftQuantumPrimitiveX.Apply(q1);
                    }

#line hidden
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.Bell.Set", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Result desired, Qubit q1)
        {
            return __m__.Run<Set, (Result,Qubit), QVoid>((desired, q1));
        }
    }

    public class BellTest : Operation<(Int64,Result), (Int64,Int64,Int64)>
    {
        public BellTest(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Primitive.CNOT), typeof(Microsoft.Quantum.Primitive.H), typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.Release), typeof(Quantum.Bell.Set) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected Allocate Allocate
        {
            get
            {
                return this.Factory.Get<Allocate, Microsoft.Quantum.Primitive.Allocate>();
            }
        }

        protected IUnitary<(Qubit,Qubit)> MicrosoftQuantumPrimitiveCNOT
        {
            get
            {
                return this.Factory.Get<IUnitary<(Qubit,Qubit)>, Microsoft.Quantum.Primitive.CNOT>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.H>();
            }
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected Release Release
        {
            get
            {
                return this.Factory.Get<Release, Microsoft.Quantum.Primitive.Release>();
            }
        }

        protected ICallable<(Result,Qubit), QVoid> Set
        {
            get
            {
                return this.Factory.Get<ICallable<(Result,Qubit), QVoid>, Quantum.Bell.Set>();
            }
        }

        public override Func<(Int64,Result), (Int64,Int64,Int64)> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.Bell.BellTest", OperationFunctor.Body, _args);
                var __result__ = default((Int64,Int64,Int64));
                try
                {
                    var (count,initial) = _args;
#line 23 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                    var numOnes = 0L;
                    // By default, Q# variables are immutable unless defined specifically as mutable
#line 24 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                    var agree = 0L;
#line 25 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                    var qubits = Allocate.Apply(2L);
#line 27 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                    foreach (var test in new Range(1L, count))
                    {
#line 29 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                        Set.Apply((initial, qubits[0L]));
#line 30 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                        Set.Apply((Result.Zero, qubits[1L]));
                        //X(qubits[0]);                 // Flip the qubit before we measure it ... this is a second classical measurement
#line 33 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                        MicrosoftQuantumPrimitiveH.Apply(qubits[0L]);
                        // The qubit is now in superposition, so half way between 0 and 1 - statistically will measure 
                        // out in either state roughly half the time (testing shows variable results)
#line 35 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                        MicrosoftQuantumPrimitiveCNOT.Apply((qubits[0L], qubits[1L]));
#line 36 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                        var res = M.Apply<Result>(qubits[0L]);
#line 38 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                        if ((M.Apply<Result>(qubits[1L]) == res))
                        {
#line 40 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                            agree = (agree + 1L);
                        }

                        // Count the number of ones we saw
#line 44 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                        if ((res == Result.One))
                        {
#line 46 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                            numOnes = (numOnes + 1L);
                            // The 'set' keyword is used to assign mutable variable values 
                            // (don't cofuse with the 'Set' operation here) 
                            ;
                        }
                    }

#line 50 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                    Set.Apply((Result.Zero, qubits[0L]));
                    // This call to 'Set' is to return the Qubit to a known state when done 
                    // - as required by the 'using' statement
#line 52 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                    Set.Apply((Result.Zero, qubits[1L]));
#line hidden
                    Release.Apply(qubits);
#line hidden
                    __result__ = ((count - numOnes), numOnes, agree);
                    // Return number of times we saw a |0> and number of times we saw a |1>
#line 55 "D:\\Git\\Q#\\Bell\\Bell\\Bell.qs"
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.Bell.BellTest", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<(Int64,Int64,Int64)> Run(IOperationFactory __m__, Int64 count, Result initial)
        {
            return __m__.Run<BellTest, (Int64,Result), (Int64,Int64,Int64)>((count, initial));
        }
    }
}